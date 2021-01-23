     public static void Start() {
                lock (initLock) {
                    if (!hasInited) {
                        // Go through all the bin assemblies
                        foreach (var assemblyFile in GetAssemblyFiles()) {
                            var assembly = Assembly.LoadFrom(assemblyFile);
    
                            // Go through all the PreApplicationStartMethodAttribute attributes
                            // Note that this is *our* attribute, not the System.Web namesake
                            foreach (PreApplicationStartMethodAttribute preStartAttrib in assembly.GetCustomAttributes(
                                typeof(PreApplicationStartMethodAttribute),
                                inherit: false)) {
    
                                // If it asks to be called after global.asax App_Start, keep track of the method. Otherwise call it now
                                if (preStartAttrib.CallAfterGlobalAppStart && HostingEnvironment.IsHosted) {
                                    attribsToCallAfterStart.Add(preStartAttrib);
                                }
                                else {
                                    // Invoke the method that the attribute points to
                                    preStartAttrib.InvokeMethod();
                                }
                            }
                        }
