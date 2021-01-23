            if(listView1.Items.Count > 1)
            {
                listView1.Items.Clear();
            }
            var listMember = new List<string>{};
            var listOnline = new List<string>{};
            // SQL PART //
    using (conn)
    {
       conn.Open();
       ///...1st Query
       QueryTwoFields("SELECT fullname,online FROM member WHERE active = '1' ORDER BY online DESC",listmember,listonline)
        //...2nd query
        QueryTwoFields("your new Select Statement",myOtherList1,myOtherlist2)    
      ....
    }
