            //array of bad chars you don't want in your data - Must be of char type 
            char [] chars=new char[] { '$','-','#'}; //Add all bad chars here...
            //define and load the datatable
            DataTable dt = new DataTable("test");
            DataColumn c0 = new DataColumn("Contacts");
            dt.Columns.Add(c0);
            DataColumn c1 = new DataColumn("Serial");
            dt.Columns.Add("c1");
            DataColumn c3 = new DataColumn("Notes");
            dt.Columns.Add(c3);
            //load some data
            dt.Rows.Add(new object[]  {"a","1234$542341","no$$tes1"} );
            dt.Rows.Add(new object[]  {"b#","12342241","notes2"} );
            dt.Rows.Add(new object[] { "c?", "-421341", "notes3" });
            dt.Rows.Add(new object[] { "DD", "12345", "notes3" });
            //loop through each cell, when a cell contains bad data,
            //remove the entire row and skip remainig cells 
            if (dt == null) return;
            Console.WriteLine("Rows before:" + dt.Rows.Count.ToString());
            if (dt.Rows.Count == 0) return;
            int c = dt.Rows.Count;
            
            for (int r = c-1; r > -1; r--)
            {
                Console.WriteLine("***Row: "); 
                
                foreach (var item in dt.Rows[r].ItemArray) // Loop over the items.
                {
                    if (item.ToString().IndexOfAny(chars) > -1)
                    {
                        Console.Write("Bad Content: ");
                        Console.WriteLine(item);
                        dt.Rows[r].Delete(); //remove row
                        break;//skip remaining cells
                    }
                }
            }
            dt.AcceptChanges();
            Console.WriteLine("Rows after:"+dt.Rows.Count.ToString());
            Console.Read();
