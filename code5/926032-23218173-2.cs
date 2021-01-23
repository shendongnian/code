      var  recordsItem=db.Records.GroupBy(x=> x.CountryID).Select( gr => new{ CID=gr.Key, Count=gr.Count()}).ToList();
      var result= (from c in db.Countries
                  join  r in  recordsItem on c.CountryID equals r.CID
                  order by r.Count descending
                  select  new  SelectListItem() 
                   {
                      Text = c.CountryName, 
                      Value =   c.CountryID.ToString()
                   }).ToList();
