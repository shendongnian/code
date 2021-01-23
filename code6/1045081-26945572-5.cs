            using (IKernel Kernel = new StandardKernel())
            {
                Kernel.Bind<IDataProvider>().To<DataProvider>();
                Kernel.Bind<IProviderFactory>()
                 .To<ProviderFactory>().WithConstructorArgument(typeof(IKernel), Kernel);
                var widget = Kernel.Get<Widget>();
                widget.Create();
                widget.Create();
            }
