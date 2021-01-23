                //Assign all source property to taget object 's properties
                foreach (PropertyInfo property in propertyInfo)
                {
                    Type t1 = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                    dynamic safeValue1 = (property.GetValue(objSource, null) == null) ? null : Convert.ChangeType(property.GetValue(objSource, null), t1, null);
                    //dynamic dcoll = property.GetValue(objTarget, null);
                    foreach (dynamic child in safeValue1)
                    {
                        objTarget = objTarget.Remove(objTarget.Length-1) + ",\"" + property.Name + "\" : [{" + CreateJsonData(child) + "}";
                        objTarget = objTarget + "}],";
                    }
                }
