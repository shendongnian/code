    var sortedTable = testTableData.AsEnumerable()
    					.Where(r => r.EFValue!=null && r.EFValue!= "")
    					.GroupBy(r => new
    					 {
    					     SID = r.SID,
    					     SName = r.SName,
    					     EID = r.EID,
    					     EFID = r.EFID   
    					 })
    					.OrderBy(g => g.Key.SID)
    					.ThenBy(g => g.Key.SName)
    					.ThenBy(g => g.Key.EID)
    					.ThenBy(g => g.Key.EFID)                                        
    
    					.Select(g => new {
    					    SID = g.Key.SID,
    					    SName = g.Key.SName,
    					    EID = g.Key.EID,
    					    EFID = g.Key.EFID,
    
    		    			Avg=g.Average(x=>x.EPoints),
    					    Y=g.Where(x=>x.FValue=="Y").Sum(x=>x.FValue),
    					    N=g.Where(x=>x.FValue=="N").Sum(x=>x.FValue)
    					});
