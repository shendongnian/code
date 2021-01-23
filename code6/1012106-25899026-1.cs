    [assembly: Dependency(typeof(Hud))]
    namespace project.iOS
    {
    	public class Hud : IHud
    	{
    		public Hud ()
    		{
    		}
    
    		public void Show() {
    			BTProgressHUD.Show ();
    		}
    
    		public void Show(string message) {
    			BTProgressHUD.Show (message);
    		}
    
    		public void Dismiss() {
    			BTProgressHUD.Dismiss ();
    		}
    	}
    }
