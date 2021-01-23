    //Obtains all users who have never been deactivated and were created prior to the month in question
    newRecord.TotalUsers = (from usr in db.tbl_Reg_User
                            join lg in db.tbl_reg_user_log on new { UserID = usr.ID } equals new { UserID = lg.userID } into lg_join
                            from lg in lg_join.DefaultIfEmpty()
                            where (usr.date_Start < temp) && usr.clientID == j.clientID && usr.clientID != 1
                            where lg.dateModified == null
                            select usr.ID).Count();
    //Obtains users who were deactivated at some point but were reactivated prior or during the month in question
    newRecord.TotalUsers += (from usr in db.tbl_Reg_User
                                join lg in db.tbl_reg_user_log on new { UserID = usr.ID } equals new { UserID = lg.userID } into lg_join
                                from lg in lg_join.DefaultIfEmpty()
                                where (usr.date_Start < temp) && usr.clientID == j.clientID && usr.clientID != 1
                                where lg.dateModified != null && lg.dateModified < temp
                                orderby lg.dateModified descending
                                group lg by lg.userID into g
                                select g).Select(x => x.Where(y => y.deactivationStatus != true)).Count();
