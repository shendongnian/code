    public class CurrentUser
    {
      private string _user;
      public string User
      {
        get { return _user; }
        set { _user = value; }
      }
      //this gets pushed in the beginning of the program
      private void btn_click(object sender, RoutedEventArgs e)
      {
         if(String.IsNullOrEmpty(txtUsername.Text)
         {
             _user = "No name";
         }
         else
         {
             _user= txtUsername.Text;
         }
      }
    }
    
    public class Game
    {
         public void DoSomething()
         {
             var myCurrentUser = new CurrentUser();
             var user = myCurrentUser.User;
             Console.WriteLine(user);
         }
    }
