                DataView dv = new DataView(dt);
                dv.Sort = "ID ASC, HireDate DESC, TermDate DESC";
    
                string lastID = "0";
                List<DateTime> addedHireDatesForUser = new List<DateTime>();
    
                foreach (DataRowView drv in dv)
                {
                    if (drv["ID"].ToString() != lastID)
                    {
                        addedHireDatesForUser = new List<DateTime>();
                        addedHireDatesForUser.Add(DateTime.Parse(drv["HireDate"].ToString()));
    
                        // NEXT ID, ADD ROW TO NEW DATATABLE
                    }
                    else if (!addedHireDatesForUser.Contains(DateTime.Parse(drv["HireDate"].ToString())))
                    {
                        addedHireDatesForUser.Add(DateTime.Parse(drv["HireDate"].ToString());
    
                        // NEXT DATE, ADD ROW TO NEW DATATABLE
                    }
                    lastID = drv["ID"].ToString();
                }
