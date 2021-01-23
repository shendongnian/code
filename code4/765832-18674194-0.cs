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
        	        var tbl2= new tbl_Sender
        	        {
         	          Lname_s = Lname,
          	          Name_s = Name,
         	          Tell_s = Tell,
        	        };
                    db.tbl_Reciver.Add(tbl1);
                    db.tblSender.Add(tbl2);
                    db.SaveChanges();
        
                    return true;
        
                }
                catch
                {
                    return false;
                }
         }
