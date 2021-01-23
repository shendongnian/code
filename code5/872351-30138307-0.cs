    // Create a list for the results
    var results = new List<YourDBResultTypeHere>();
    foreach(tbx CurTBX in ALLFILTERTBX)
    {
       switch(CurTBX.Name) {
          case "email":
             results.AddRange(db.Where(db => db.email.Contains(tbx.Text)).ToList());
             break;
          case "name":
             results.AddRange(db.Where(db => db.name.Contains(tbx.Text)).ToList());
             break;
       }
    }
