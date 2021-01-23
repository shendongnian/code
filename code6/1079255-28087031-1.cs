    [assembly: Xamarin.Forms.Dependency (typeof (ChessUser_Android))]
    public class ChessUser_Android : Java.Lang.Object, UserInterface {
	
	    public void saveUserName(string userName){
		    var prefs = Application.Context.GetSharedPreferences("MyApp", FileCreationMode.Private);
		    var prefEditor = prefs.Edit();
		    //save user's properties for a specific key
		    prefEditor.PutString("user_name",userName);
		    prefEditor.Commit();
	    }
	    public string loadUserName(){
	 	    var prefs = Application.Context.GetSharedPreferences("MyApp",     FileCreationMode.Private); 
		    return prefs.GetString("user_name",null);
	    }
    }
