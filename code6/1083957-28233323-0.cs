    foreach (var iType in controlAssembly.GetTypes()) {
                    if (!iType.IsAbstract 
                        && typeof(System.Windows.Forms.Control /*or better use your own ControlBase or ControlInterface Type here*/ ).IsAssignableFrom(iType)
                        && iType.GetConstructor(Type.EmptyTypes) != null) {
                            var control = iType.GetConstructor(Type.EmptyTypes).Invoke(null);
                            //add to tabControl here
                    }
                }
