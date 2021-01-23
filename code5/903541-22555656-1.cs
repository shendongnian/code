    var regs = Classes
               .FromThisAssembly()
               .Pick()
               .WithServiceAllInterfaces(); // dummy registration
    regs.Configure(c => c.IsDefault());
