    public class UserData { string username; string password; }
    
    var userData = new UserData() { username = "Tom", password = "XXXXXXXX" };
    
    UserData[] arr = new UserData[] { userData };
    
    string json_data = JsonConvert.SerializeObject(arr); // this is the Newtonsoft API method
    // json_data will be equal to [{"result":{"username":"Tom","password":"XXXXXXX"}}] 
    
    MessageBox.Show(json_data); 
