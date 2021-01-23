        var model = from personnel in DB.RFH_Personnel 
                    select new personnelViewModel  { 
                                                    PKPersonelID = personnel.PKPersonelID,
                                                    name = personnel.Name,
                                                    family = personel.Family, 
                                                    usageCount = DB.RFH_Service.Count(d => d.FKPersonelID == personnel.PKPersonelID)
                                                   };
