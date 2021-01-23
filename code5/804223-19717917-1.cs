    public class MyViewModel : IViewAware
    {
        public void DoSomethingThatAffectsView()
        {
            var view = this.GetView() as MyView;
        
            view.SomePageControl.SomeMethod();
        }
    }
