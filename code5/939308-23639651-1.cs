      [SqlProcedure]
      public static void MBhello(SqlString yousaid)
      {
        if (yousaid.IsNull)
        {
          yousaid = "Not too chatty are you " + Environment.UserDomainName + "\\" + Environment.UserName;
          SqlContext.Pipe.Send("Mercedes Benz says, '" + yousaid.ToString() + "'\n");
        }
        else
        {
          SqlContext.Pipe.Send("Mercedes Benz says, you said '" + yousaid.ToString() + "'\n");
        }
      }
