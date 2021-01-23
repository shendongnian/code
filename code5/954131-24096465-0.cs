    public class UserData { string username; string password; }
    
    var userData = new UserData() { username = "username", password = "XXXXXXXX" };
    
    UserData[] arr = new UserData[] { userData };
    
    string json_data = JsonConvert.SerializeObject(arr); // this is the Newtonsoft API method
    
    MessageBox.Show(json_data);
