     builder.RegisterType<ClassThatNeedsILog>()
         .AsImplemen‌​tedInterfaces()
         .WithParameters(new Parameter[] {
             ResolvedParameter.ForNamed<IAnotherInterface>("NAME"),
             ResolvedParameter.ForNamed<IYetAnotherInterface>("ANOTHERNAME")});
