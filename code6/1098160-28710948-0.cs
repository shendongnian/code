    if (prop.PropertyType.IsEnum)
                                    {
                                        Object valueSet = Enum.Parse(prop.PropertyType, childElement.Value, true);
                                        prop.SetValue(obj, valueSet, null);
                                    }
                                    else
                                    {
                                        prop.SetValue(obj, Convert.ChangeType(childElement.Value, prop.PropertyType), null);
                                        break;
                                    }
