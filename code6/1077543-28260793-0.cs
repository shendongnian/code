    [assembly: ExportRenderer (typeof (CustomNavigationalPage), typeof (CustomNavigationPageRenderer))]
    namespace project.iOS
    {
      public class CustomNavigationPageRenderer : NavigationRenderer
      {
          public CustomNavigationPageRenderer()
          {
          }
          public override void ViewDidLoad ()
          {
              base.ViewDidLoad ();
              //Background image
              this.NavigationBar.BarTintColor = UIColor.FromPatternImage (UIImage.FromFile ("AnyResourceImage.png"));
              //Your desire color
              this.NavigationBar.BarTintColor = UIColor.Red; 
              //Right item color
              this.NavigationBar.TopItem.RightBarButtonItem.TintColor = UIColor.FromPatternImage (UIImage.FromFile ("AnyResourceImage.png"));
              //Left item color
              this.NavigationBar.TopItem.LeftBarButtonItem.TintColor = UIColor.Black;
          }
       }
    }
