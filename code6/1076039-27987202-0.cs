            Persona persona = new Persona();
            ArrayList propertiesThatCanBeFiltered = new ArrayList();
            var metaDatas = ModelMetadataProviders.Current.GetMetadataForProperties(persona, persona.GetType());
            foreach (var metaData in metaDatas)
            {
                foreach (var av in metaData.AdditionalValues)
                {
                    if (av.Key == "Filtrable")
                        propertiesThatCanBeFiltered.Add(metaData.PropertyName);
                }
            }
