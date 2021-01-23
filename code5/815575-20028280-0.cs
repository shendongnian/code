    string[] split = new string[] { };
                    if (Helper.DepartmentFilter != null)
                    {
                        split = Helper.DepartmentFilter.Split(',');
                    }
                    var splitLength = split.Length;
                    using (dbEntities Context = new dbEntities())
                    {
                        var result = (from me in Context.master_employee
                                      join ud in Context.user_detail on me.employeeid equals ud.employeeid
                                      where me.status.Equals("A")
                                      && (splitLength  == 0 || split.Contains(me.department))
                                      select new
                                      {
                                          ud.email,
                                          me.employeeid,
                                          me.name
                                      }).ToList();
    
                        return result;
                    }
