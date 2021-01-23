    public class FormB : Form
    {
         public delegate void OnNewUserRegistered(string username)
         public OnNewUserRegistered NewUserRegistered;
         ....
         protected void cmdRegister_Click(object sender, EventArgs e)
         {
             // Code to register the user
             string username = txtUserName.Text;
             ..... etc .....
            
             // If someone has registered a subscription then call that subscription handler
             if(NewUserRegistered != null)
                  NewUserRegistered(username); 
        
         }
    }
