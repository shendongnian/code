    var users = allusersList.Where(a => a.FirstName =="some value").ToList();
    foreach (var item in users)
    {
          ListBoxDS.Add(new Users { UserID = item.Id, UserName = item.Username,FirstName=item.firstname });
     }
