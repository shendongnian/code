    public class loginc
    {
      public static username;
      public static pass;
    ...
    ...
     string query = "SELECT * FROM logon.login where username = @user and password = @pass";
    cmd.Parameters.AddWithValue(@user,username);
    cmd.Parameters.AddWithValue(@pass,pass);
