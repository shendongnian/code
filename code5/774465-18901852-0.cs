            foreach (DbEntityEntry entity in entities)
            {
                foreach (string propertyName in entity.CurrentValues.PropertyNames)
                {
                    var propertyInfo = entity.Entity.GetType().GetProperty(propertyName);
                    var propertyType = propertyInfo.GetType();
                }
            }
