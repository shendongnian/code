    JavaScriptSerializer oSerializer = new JavaScriptSerializer();
    
    var Result = (from c in dt.AsEnumerable()
    			  select new
    			  {
    				  Flag = c.Field<bool>("Flag"),
    				  Status = c.Field<string>("Status")
    			  }).ToList();
    
    hdnControl.Value = oSerializer.Serialize(Result);
