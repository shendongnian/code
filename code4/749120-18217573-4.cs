    var totalRows = dt.AsEnumerable()                  
                      .Select(p=>                     
                      {
                         p["Value"] = (DynamicControlsHolder1.FindControl(p.Field<string>("ID")) as TextBox) ?? "";
                         return p;
                      }).Count();
