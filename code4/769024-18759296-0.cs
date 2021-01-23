    class ContentViewModel{
 
     IView view;
     public ContentViewModel(IContentAView view)
           {
                View = view;
                View.ViewModel = this;
