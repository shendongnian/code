    string myConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Environment.CurrentDirectory + "\\MYDATABASE.accdb;Persist Security Info=False";
    
    OleDbConnection myDBConnection = null;
    
    int myEnabled = 0;
    
    if (checkBox1.Checked == true)
    
    {
    
       myEnabled = -1; // Set as checked or Yes in MS-Access on a Yes/No Data Type Field
    
       myComment+= ", Account=Enabled";
    
    }
    
    else
    
    {
    
       myEnabled = 0; // Set as unchecked or No in MS-Access on a Yes/No Data Type Field
    
       myComment += ", Account=Disabled";
    
    }
    
    myDBConnection = new OleDbConnection(myConnectionString);
    
    myDBConnection.Open();
    
    string myDateTimeStamp = DateTime.Now.ToString();
    
    myDBCommand = new OleDbCommand("insert into tblAuthorizedUsers (USERID, Fullname, AuthorizationLevel, EnabledDisabled, USERIDMaker, DateTimeStamp) values('" + textBox1.Text.Trim().ToUpper() + "','" + textBox2.Text.Trim() + "','" + myAuthorizationLevel + "','" + myEnabled + "','" + Environment.UserName.Trim().ToUpper() + "','" + myDateTimeStamp + "')", myDBConnection);
    
    myDBCommand.ExecuteNonQuery(); // With this you can handles multiple inserts to a MSAccess table even if this line is inside of the loop of multiple records handling
