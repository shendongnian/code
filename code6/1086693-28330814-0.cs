    ViewData["listDT"] = from c in Enum.GetValues(typeof(ColumnDataType)).Cast<ColumnDataType>().ToList()
                         where    c == ColumnDataType.String 
                               || c == ColumnDataType.DateTime 
                               || c == ColumnDataType.Decimal
                               || c == ColumnDataType.Integer 
                         select new SelectListItem { Value = c.ToString(), Text = c.ToString() };
