    public interface IViewFor<in TViewModel>
        where TViewModel : IDataSelectViewModel
    { 
        void Do(TViewModel vm); // allowed
        TViewModel Do(); // disallowed
    }
