    void worker1_DoWork(object sender, DoWorkEventArgs e)
    {
        if (((CheckBox)e.Argument).Checked == true)
        {
         ....Some Codes
             using(var db = new MyFooEntities())
             {
                 var vv = (from value in db.tblValue 
                           join addres in db.tblAddres on value.AddresID equals addres.ID 
                           where value.AddresID == addresID && 
                                 value.LoopDate >= startDate && 
                                 value.LoopDate<= finishDate 
                           orderby value.LoopDate 
                           select new { value, addres }).ToList();
             }
         ....Some Codes
         }
    }
