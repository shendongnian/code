    var SubGrpDisplayDocs = (from m in dtGrpDisplays.AsEnumerable()                        
                                                select m).ToList();
    var DtDownloads = (from m in DtDownloads.AsEnumerable()
                                        select m).ToList(); 
    ViewBag.Data = from m in SubGrpDisplayDocs
                                    join n in DtDownloads on m.GroupID equals n.GroupID
                                    where m.GroupID = n.GroupID
                                    select m;    
