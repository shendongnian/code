            if ((objectCreationHandling != ObjectCreationHandling.Replace)
                && (tokenType == JsonToken.StartArray || tokenType == JsonToken.StartObject)
                && property.Readable)
            {
                currentValue = property.ValueProvider.GetValue(target);
                gottenCurrentValue = true;
                if (currentValue != null)
                {
                    ...
                    useExistingValue = (
                       !propertyContract.IsReadOnlyOrFixedSize &&
                       !propertyContract.UnderlyingType.IsValueType());
                }
            }
