    using System.Web.Script.Serialization;
    [WebMethod (Description = "Get Strapping by passing StapKeyId") ]
    public string GetStrapping(string strapKeyId)
    {
    	
    	var json = string.Empty;
    	var railcar = from r in dc.tblRailcars
    				  join s in dc.tblStraps on r.TankStrapping_KeyID equals s.KeyId
    				  where r.TankStrapping_KeyID == Int32.Parse(strapKeyId)
    				  select new 
    				  { 
    					  r.RailcarMark, 
    					  r.RailcarNumber,
    					  r.TankStrapping_KeyID,
    					  s.Capacity,
    					  s.TableNumber,
    					  s.TableType
    				  };
    
    	JavaScriptSerializer jss = new JavaScriptSerializer();
       json = jss.Serialize(railcar);
    
    	return json;
    }
