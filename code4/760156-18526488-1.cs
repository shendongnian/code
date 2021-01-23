    var query = MemberBasicData
                .Join
                (
                    MemberDetail,
                    x=>x.Id,
                    x=>x.Mem_Id,
                    (b,d)=>new
                    {
                        b.Id,
                        b.Mem_NA,
                        b.Mem_Occ,
                        d.Mem_Id ,
                        d.Mem_Role,
                        d.Mem_Email,
                        d.Mem_MPh ,
                        d.Mem_DOB ,
                        d.Mem_BGr ,
                        d.Mem_WAnn ,
                        d.Mem_Spouse, 
                        d.Mem_Web 
                    }
                 )
