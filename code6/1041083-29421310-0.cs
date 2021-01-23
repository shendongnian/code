    builder.RegisterAssemblyTypes( GetType().Assembly )
        .AssignableTo<ViewModelBase>()
        .OnActivated( args =>
        {
            var viewModel = args.Instance as ViewModelBase;
            if( viewModel != null )
            {
                viewModel.MyProp = args.Context.Resolve<ISomeClass>();
            }
        } );
