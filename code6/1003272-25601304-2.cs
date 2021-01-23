      IQueryable<RelCU> Query = from u in dbEntities.UserInfoes
                                join m in dbEntities.RelCUs
                                on u.UserID equals m.UserID into temp
                                from j in temp.DefaultIfEmpty()
                                select new
                                {
                                    ID=u.UserID, 
                                    FirstName=u.FirstName,
                                    LastName=u.LastName,
                                    Score = j == null? 0 : j.Score,
                                    Status = j == null? "" :j.Status
                                };
      DataGridRegisteredUsers.ItemsSource = Query;
