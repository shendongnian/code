    public static void PopulateFromMessage<T, TS>(T targetEntity, TS message)
        {
            var sourceType = typeof (TS);
            var targetType = typeof (T);
            foreach (var targetPropInfo in targetType.GetProperties())
            {
                if (targetPropInfo.PropertyType.IsGenericType)
                {
                    if (targetPropInfo.PropertyType.GetGenericTypeDefinition() == typeof(IList<>))
                    {
                        var originalList = sourceType.GetProperty(targetPropInfo.Name).GetValue(message) as IList;
                        if (originalList != null)
                        {
                            var argumentType = targetPropInfo.PropertyType.GetGenericArguments();
                            var listType = typeof (List<>);
                            var concreteType = listType.MakeGenericType(argumentType);
                            var newList = Activator.CreateInstance(concreteType) as IList;
                            foreach (var original in originalList)
                            {
                                var targetValue = Activator.CreateInstance(argumentType[0]);
                                // do this yourself. Here we're converting ValueDefinition to TargetValueDefinition
                                // targetValue.Fill(original);
                            }
                            targetPropInfo.SetValue(targetEntity, newList);
                        }
                    }
                }
                else
                {
                    if (sourceType.GetProperty(targetPropInfo.Name) != null)
                    {
                        var obj = sourceType.GetProperty(targetPropInfo.Name);
                        if (obj.PropertyType.Namespace == "System.Collections.Generic")
                        {
                            //var x = targetType.GetProperty(targetPropInfo.Name);
                            //PopulateFromMessage(ref x, sourceType.GetProperty(targetPropInfo.Name));
                            continue;
                        }
                        targetPropInfo.SetValue(targetEntity, sourceType.GetProperty(targetPropInfo.Name).GetValue(message), null);
                    }
                }
            }
        }
