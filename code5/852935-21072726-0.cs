    var joined = (from item1 in loginList 
                             join item2 in users
                             on item1.LoginId equals item2.LoginId
                             orderby item1.LoginId
                              select new
                              {
                                  item1.Password,
                                  item2.LoginId,
                                  item2.FullName,
                                  item2.FatherName,
                                  item2.DOB,
                                  item2.JoinDate
                              }).Distinct().ToList();
