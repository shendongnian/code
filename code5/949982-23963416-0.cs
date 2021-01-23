    var groupList = from g in groups
                    group g by g.Field<string>("id").ToString().Split('-').First() into Group1
                    select new { Column1 = Group1.Key, Properties = Group1 };
        
    var allGrps = groupList.ToList();
    var FirstGrp= allGrps[1].Properties.ToList();
    var FirstItemOfFirstGroup= FirstGrp[0].ItemArray.First();
