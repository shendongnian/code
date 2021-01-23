    [assembly: Xamarin.Forms.Dependency (typeof (ChessUser_iOS))]
    public class ChessUser_iOS : UserInterface {
        
        public void saveUserName(string userName){
		   var prefs = NSUserDefaults.StandardUserDefaults;
           //save user's properties for a specific keys
		   prefs.SetValueForKey (new NSString (userName), new NSString ("user_name"));
        }
        public string loadUserName(){
		     var prefs = NSUserDefaults.StandardUserDefaults;
             return prefs.StringForKey ("username");
        }
    }
