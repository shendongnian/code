    protected void GridView1_RowCommand(...)
    {
       switch ( e.CommandName )
       {
          case "AcceptRequestcmd" :
             string rowid = e.CommandArgument;
       }
    }
