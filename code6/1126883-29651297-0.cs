    // Add the in modifier
    public interface IViewFor<in TViewModel>
        where TViewModel : IDataSelectViewModel
    { }
    // register it this way
    builder.RegisterType<DataSelectView>().As<IViewFor<DataSelectViewModel>>();
