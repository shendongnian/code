    partial class BViewController : UIViewController
	{
		const string server = "server";
		const string port = "port";
		const string password = "password";
		const string username = "username";
		const string inboxuserid = "inboxuserid";
        .............
        .............
      public override void ViewWillDisappear (bool animated)
      {
        var appDefaults = new NSDictionary (server, serverTF.Text, port, portTF.Text, password, passwordTF.Text,username,usernameTF.Text, inboxuserid,inboxuserTF.Text);
      }
    }
