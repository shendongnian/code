    var query = (from e in db.MyTab
               join f in db.MyOtherTab on e.TypeId equals MyOtherTab.TypeId
               select new 
               {
                   Tab = e,
                   OtherTab = f   
               }).ToList();
    var list = new SelectList(query.Select(e=>
                   new 
                   {
                      Text = string.Format("{0} {1} {2} {3} {4} {5}", e.Tab.Name,e.Tab.Code, e.OtherTab.TypeDescription ,e.Tab.Class ,e.Tab.Series ,e.Tab.InterestRate),
                      Value = e.Tab.Id
                   }, "Value", "Text");
