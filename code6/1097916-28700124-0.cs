    var asm = ...;
    var internals = asm.GetCustomAttributes(typeof(InternalsVisibleToAttribute),
                                            false);
    var foundDynamicProxy2 = internals.Cast<InternalsVisibleToAttribute>()
                                      .Any(x => x.AssemblyName == "DynamicProxy2");
