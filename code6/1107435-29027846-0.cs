    //First I get a list of all the folders
    var queryFolders = from f in db.FOLDERS
                       orderby f.Name
                       select new
                       {
                           f.Name
                       };
    //Here there's the query I was looking for
    var queryAccess = from f in db.FOLDERS
                      from u in db.USERS
                      orderby f.Name
                      select new
                      {
                          User = u.Name,
                          Access = u.FolderAccess.Any(x => x.ID_Folder == f.ID_Folder)
                      }
                      into crossJoin
                      group crossJoin by new { crossJoin.User } into results
                      select new
                      {
                          results.Key.User,
                          AccessList = results.Select(x => x.Access).ToArray()
                      };
    
    //Now I wrap the queries into a DataTable so I can easily feed them to what I need
    DataTable dtAccess = new DataTable();
    dtAccess.Columns.Add("User");
    foreach (var f in queryFolders)
    {
        dtAccess.Columns.Add(f.Name, typeof(bool));
    }
    foreach (var a in queryAccess)
    {
          DataRow userFolders = dtAccess.NewRow();
          userFolders["User"] = a.User;
          for (int i = 1; i <= a.AccessList.Length; i++)
          {
              userFolders[i] = a.AccessList[i - 1];
          }
          dtAccess.Rows.Add(userFolders);
    }
