            Persona persona = new Persona();
            ArrayList propertiesThatCanBeFiltered = new ArrayList();
            var metaDatas = ModelMetadataProviders.Current.GetMetadataForProperties(persona, persona.GetType());
            foreach (var metaData in metaDatas)
            {
                if (metaData.AdditionalValues.ContainsKey("Filtrable"))
                    propertiesThatCanBeFiltered.Add(metaData.PropertyName);
            }
