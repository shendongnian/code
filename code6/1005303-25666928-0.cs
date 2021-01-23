        public virtual WriteConcernResult Update(IMongoQuery query, IMongoUpdate update, MongoUpdateOptions options)
        {
            var updateBuilder = update as UpdateBuilder;
            if (updateBuilder != null)
            {
                if (updateBuilder.Document.ElementCount == 0)
                {
                    throw new ArgumentException("Update called with an empty UpdateBuilder that has no update operations.");
                }
            }
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }
            var queryDocument = query == null ? new BsonDocument() : query.ToBsonDocument();
            var updateDocument = update.ToBsonDocument();
            var messageEncoderSettings = GetMessageEncoderSettings();
            var isMulti = options.Flags.HasFlag(UpdateFlags.Multi);
            var isUpsert = options.Flags.HasFlag(UpdateFlags.Upsert);
            var writeConcern = options.WriteConcern ?? _settings.WriteConcern ?? WriteConcern.Acknowledged;
            var operation = new UpdateOpcodeOperation(_collectionNamespace, queryDocument, updateDocument, messageEncoderSettings)
            {
                IsMulti = isMulti,
                IsUpsert = isUpsert,
                WriteConcern = writeConcern
            };
            using (var binding = _server.GetWriteBinding())
            {
                return operation.Execute(binding, Timeout.InfiniteTimeSpan, CancellationToken.None);
            }
        }
