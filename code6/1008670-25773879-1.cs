    public interface IViewProvider<TView, TModel> where TView : IView<TModel>
    {
        TView GetViewByKey(object key);
    }
    
