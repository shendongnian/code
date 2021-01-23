    foreach (var item in FirmControlInfo)
                {
                    var propInfo = System.Reflection.RuntimeReflectionExtensions.GetRuntimeProperties(typeof(RequestViewModel1)).Where(pi => pi.Name == item.ControlName).First();
                    propInfo.SetValue(request, AbNoSub);
                }
