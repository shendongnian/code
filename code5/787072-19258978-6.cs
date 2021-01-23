    bool isValidLogin = false;
    String userID = String.Empty;
    for(int i = 0; i<dt.Rows.Count; i++)
    {
       if(dt.Rows[i][1].ToString() == passwordText)
       {
          isValidLogin = true;
          userID = dt.Rows[0][0].ToString();
          break;
       }
    }
