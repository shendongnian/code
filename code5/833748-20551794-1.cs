    #region Test
            foreach (var item in mappingAssembly.GetTypes())
            {
                var mappingObj = Activator.CreateInstance(item);
                var modelName = mappingObj.GetType().GetProperty("ModelName").GetValue(mappingObj);
                var modelTypeEquivalent = modelAssembly.GetTypes().First(x => x.Name.Equals(modelName));
                var convertionMethod = typeof(MappingTransformation).GetMethod("Convert");
                var genericConvertionMethod = convertionMethod.MakeGenericMethod(modelTypeEquivalent);
                var result = genericConvertionMethod.Invoke(null, new object[] { mappingObj });
                var breakpoint = true;
            }
    #endregion
