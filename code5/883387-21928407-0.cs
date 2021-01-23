    protected void Button2_Click(object sender, EventArgs e)
        {
             try
            {
                string s = null;
                int  limit = 4;
                string[] DBvalues = new string[5];
                 
                for (int parcount = 0; parcount <=limit; parcount++)
                {
                    s = Request.Form["TextBox" + parcount.ToString()];
                    if (parcount == 0)
                    {
                        DBvalues[parcount] = txt1.Text;
                    }
                    else
                    {
                        DBvalues[parcount] = Request.Form["TextBox" + (parcount + 1).ToString()];
                    }
                   
                    
                    //}
                }
                rows = g1.ExecDB("insert into tbl_products(product1,product2,product3,product4,product5) values('" + DBvalues[0].ToString() + "','" + DBvalues[1].ToString() + "','" + DBvalues[2].ToString() + "','" + DBvalues[3].ToString() + "','" + DBvalues[4].ToString() + "')");
                Response.Write(DBvalues);
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
