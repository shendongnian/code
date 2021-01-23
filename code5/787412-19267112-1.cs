    public int Insert (object obj, string extra, Type objType)
    {
    	if (obj == null || objType == null) {
    		return 0;
    	}
    	
        
    	var map = GetMapping (objType);
    
        #if NETFX_CORE
        if (map.PK != null && map.PK.IsAutoGuid)
        {
            // no GetProperty so search our way up the inheritance chain till we find it
            PropertyInfo prop;
            while (objType != null)
            {
                var info = objType.GetTypeInfo();
                prop = info.GetDeclaredProperty(map.PK.PropertyName);
                if (prop != null) 
                {
                    if (prop.GetValue(obj, null).Equals(Guid.Empty))
                    {
                        prop.SetValue(obj, Guid.NewGuid(), null);
                    }
                    break; 
                }
    
                objType = info.BaseType;
            }
        }
        #else
        if (map.PK != null && map.PK.IsAutoGuid) {
            var prop = objType.GetProperty(map.PK.PropertyName);
            if (prop != null) {
                if (prop.GetValue(obj, null).Equals(Guid.Empty)) {
                    prop.SetValue(obj, Guid.NewGuid(), null);
                }
            }
        }
        #endif
    
    
    	var replacing = string.Compare (extra, "OR REPLACE", StringComparison.OrdinalIgnoreCase) == 0;
    	
    	var cols = replacing ? map.InsertOrReplaceColumns : map.InsertColumns;
    	var vals = new object[cols.Length];
    	for (var i = 0; i < vals.Length; i++) {
    		vals [i] = cols [i].GetValue (obj);
    	}
    	
    	var insertCmd = map.GetInsertCommand (this, extra);
    	var count = insertCmd.ExecuteNonQuery (vals);
        long id = 0;    //New line
        if (map.HasAutoIncPK)
        {
    		id = SQLite3.LastInsertRowid (Handle);  //Updated line
    		map.SetAutoIncPK (obj, id);
    	}
    
        //Updated lines
        //return count; //count is row affected, id is primary key
        return (int)id;
        //Updated lines
    }
