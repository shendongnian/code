        static public T CreateDiffEntity<T>(T entity1, T entity2) where T : new()
        {
            T result = new T();
            foreach (var property in typeof(T).GetProperties())
            {
                var valuePropertyEntity1 = property.GetValue(entity1);
                var valuePropertyEntity2 = property.GetValue(entity2);
                if (!valuePropertyEntity1.Equals(valuePropertyEntity2))
                    property.SetValue(result, valuePropertyEntity2);
                else
                    property.SetValue(result, null);
            }
            return result;
        }
    
