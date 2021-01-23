    string id = "A01";
    
    var q = from R in db.Reservations
                        where R.Flight_NO == id
                        select R.Seat;
            foreach (var item in q)
            {
                Button b = (Button)this.Master.FindControl("main").FindControl(item);
                if (b!=null)
                {
                    b.Enabled = false;
                }
            } 
