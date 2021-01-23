    ViewData["listDT"] = from c in new[] 
                         { 
                          ColumnDataType.String,
                          ColumnDataType.DateTime, 
                          ColumnDataType.Decimal, 
                          ColumnDataType.Integer 
                         }
                         select new SelectListItem 
                         { 
                          Value = c.ToString(), 
                          Text = c.ToString() 
                         };
