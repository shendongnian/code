        string uname=TextBox1.Text;
        string pwd=TextBox3.Text;
        string mnumber = TextBox7.Text;
        string sques = DropDownList1.Text;
        string res = TextBox8.Text;
        string adress = TextBox4.Text;
        string cty = TextBox5.Text;
        string zpcode = TextBox6.Text;
        SqlCommand newcomm = new SqlCommand(@"INSERT INTO regforswa
                 (username,password,mno,sq,response,address,city,zipcode) VALUES  
                 (@uname,@pwd,@mnumber,@sques,@res,@adress,@cty,@zpcode)", conn);
         newcomm.Parameters.AddWithValue("@uname", uname);
         ..... and so on for the other parmaters required by the placeholders
         
         if (newcomm.ExecuteNonQuery() == 1)
