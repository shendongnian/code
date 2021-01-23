          Using(MyContext db = new MyContext())
          {
            try
            {
                var tbl1 = new tbl_Reciver
                {
                    id = MaxIdInTbl (),
                    Address_s = Address,
                    Cod_s = Cod,
                    Cost_s = cost,
                };
                long maxId=MaxIdInTbl();
                var tbl2= db.tbl_Sender.FirstOrDefault(x => x.id == maxId);
                
                tbl2.Lname_s = Lname;
                tbl2.Name_s = Name;
                tbl2.Tell_s = Tell;
                
                db.Refresh(RefreshMode.StoreWins,tbl2);
                db.tbl_Reciver.Add(tbl1);
                
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
         }
