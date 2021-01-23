            string[] id = new string(1); 
            id[0] = reader["id"].ToString();
            string price250g = reader["Price250g"].ToString();
            string price1kg = reader["Price1kg"].ToString();
            string templabel = null; 
            foreach (string i in id)
            {
                templabel = lbx + i;
                var matches = this.Controls.Find(templabel, true).GetValue(0);
                ((Label)matches).Text = price250g;
            }                         
