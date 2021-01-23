    var memberlist = (from memlist in objcontext.tblusers
                      memlist.logname.ToUpper().Contains(member.ToUpper())
                      select new tbluser
                      {
                          userid = memlist.userid,
                          logname = memlist.logname,
                          decription = memlist.description
                      }
                     ).ToList();
