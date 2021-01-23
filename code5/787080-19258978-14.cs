    bool isValidLogin = false;
    String userID = String.Empty;
    if(dt.Rows.Count > 0)
    {
        for(int i = 0; i<dt.Rows.Count; i++)
        {
           if(dt.Rows[i][1].ToString() == passwordText)
           {
              isValidLogin = true;
              userID = dt.Rows[i][0].ToString();
              break;
           }
        }
    }
