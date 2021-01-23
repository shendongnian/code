    public class MyViewModel : IViewAware
    {
        public void DoSomethingThatAffectsView()
        {
            var myview = this.GetView() as MyView;
            if(myview != null)        
                myview.SomePageControl.SomeMethod();
            var myotherview = this.GetView() as MyOtherView;
            if(myotherview != null)        
                myotherview.SomePageControl.SomeMethod();
            // ad infinitum...
        }
    }
