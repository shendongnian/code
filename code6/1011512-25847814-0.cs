    var props = typeof(TimesheetModel).GetProperties();
    
                   DataTable dt= new DataTable();
                    dt.Columns.AddRange(
                      props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray()
                    );
    
                    employeesNotEnteredTimesheetList.ForEach(
                      i => dt.Rows.Add(props.Select(p => p.GetValue(i, null)).ToArray())
                    );
    
     var list1 = (from p in dt.AsEnumerable()                         
                            select p).ToList();
