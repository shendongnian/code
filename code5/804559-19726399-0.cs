    public static IEnumerable<SelectListItem> Get_List()
            {
                var selectList = (from c in table
                            select new SelectListItem
                            {
                                Text = c.Date_In_Table.ToString("dd/MM/YYYY"),
                                Value = c.Date_In_Table
                            }
                        );
    
                return selectList;
        }
