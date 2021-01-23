        private void SerializeDiscriminatedValue(BsonSerializationContext context, BsonSerializationArgs args, object value, Type actualType)
        {
            var serializer = BsonSerializer.LookupSerializer(actualType);
            var polymorphicSerializer = serializer as IBsonPolymorphicSerializer;
            // Added line
            var assignableToDictionaryOrEnumerable = typeof(IDictionary<string, object>).IsAssignableFrom(actualType) || typeof(IEnumerable<object>).IsAssignableFrom(actualType);
            if (polymorphicSerializer != null && polymorphicSerializer.IsDiscriminatorCompatibleWithObjectSerializer)
            {
                serializer.Serialize(context, args, value);
            }
            else
            {
                // Edited line
                if (assignableToDictionaryOrEnumerable || (context.IsDynamicType != null && context.IsDynamicType(value.GetType())))
                {
                    // We want this code to be executed for types that should be serialized without _t and _v fields
                    args.NominalType = actualType;
                    serializer.Serialize(context, args, value);
                }
                else
                {
                    var bsonWriter = context.Writer;
                    var discriminator = _discriminatorConvention.GetDiscriminator(typeof(object), actualType);
                    bsonWriter.WriteStartDocument();
                    bsonWriter.WriteName(_discriminatorConvention.ElementName);
                    BsonValueSerializer.Instance.Serialize(context, discriminator);
                    bsonWriter.WriteName("_v");
                    serializer.Serialize(context, value);
                    bsonWriter.WriteEndDocument();
                }
            }
        }
