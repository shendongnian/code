      [SqlProcedure]
      public static void hello(SqlString yousaid)
      {
        if (yousaid.IsNull)
        {
          yousaid = "Not too chatty are you " + Environment.UserDomainName + "\\" + Environment.UserName;
          SqlContext.Pipe.Send("Mercedes Benz says, '" + yousaid.ToString() + "'\n");
        }
        else
        {
          SqlContext.Pipe.Send("The CLR proc says, you said '" + yousaid.ToString() + "'\n");
        }
      }
