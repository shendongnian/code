    IKernel kernel = new StandardKernel();
                kernel.Bind(x =>
                    x.FromThisAssembly()         // Scans currently assembly
                     .IncludingNonePublicTypes() // Including Non-public types
                     .SelectAllClasses()         // Retrieve all non-abstract classes
                     .BindDefaultInterface());   // Binds the default interface to them, e.g. class name without preceding "I"
    var Form1Presenter = kernel.Get<Form1Presenter>();
