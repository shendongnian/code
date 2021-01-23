            var q = from c in context.GetTable<tbl_user>()
                    where c.user_ID == lbuserid.Text.ToString()
                    select new
                    {
                        c.Username,
                        c.firstname
                      
                    };
            foreach (var item in q)
            {
                lbusername.Text = item.Username.ToString();
                lbfirstname.Text = item.firstname.ToString();
            }
