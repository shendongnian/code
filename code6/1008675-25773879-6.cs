    public interface IView<TModel>
    {
        IViewModel<TModel> ViewModel { get; }
    }
    
    public interface IViewModel<TModel>
    {
        TModel Model { get; set; }
    }
