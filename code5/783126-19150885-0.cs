    protected void logInButton_Click(object sender, EventArgs e)
    {
    string usernameListString = File.ReadAllText(Server.MapPath("~") 
          + "/App_Data/usernameFile.txt");
    string[] userAray = usernameListString.Split(' ');
    bool usernameExists = false;
    for (int  i = 0; i < userAray.Length; i++)
    {
        if (userAray[i] == "kevin123")
        {
          // your statements
        }
