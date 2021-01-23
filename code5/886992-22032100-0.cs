      Settings setting_ = .... // not null 
      var actions = new List<Action<TT1,TT2>>();
      if (!string.IsNullOrEmpty(setting_.Name))
      {
          actions.Add((t1,t2) => t2.Rename(t1, setting_.Name););
      }
 
      if (setting_.Settings != null)
      {
          actions.Add((t1,t2) => t2.ChangeSettings(t1, settings_.Settings));
      }
      if (setting_.Location != null)
      {
          actions.Add((t1,t2) => t2.ChangeLocation(t1, settings_.Location));
      }
      if (actions.Any())
      {
          foreach( var item in ItemsCollection)
          {
             var tt1 = item.GetTT1();
             var tt2 = item.GetTT2();
    
             foreach (var action in actions)
             {
                 action(tt1,tt2);
             }
          }
      }
