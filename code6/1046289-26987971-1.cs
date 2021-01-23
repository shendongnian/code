    IBindingRoot.Bind<ITerminal>().To<Vx580>()
        .When(ctx =>
        {
            ConstructorArgument configConstructorArgument = 
                ctx.Parameters
                   .OfType<ConstructorArgument>()
                   .Single(x => x.Name == "config");
                    
            var config = (ITerminalConfig)configConstructorArgument.GetValue(null, null);
            return config.Type == "Vx520";
        });
