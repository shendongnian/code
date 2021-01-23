    IEnumerable<Parent> list = from p in ds.Tables[0].AsEnumerable()
               select new Parent
               {
            	   Name = p["ParentName"].ToString(),
            	   childs = from c in ds.Tables[1].AsEnumerable()
                	where p["ParentId"] == c["ParentId"]
                	group c by c["ChildRowName"] into groupitems
                	select new Child
                	{
                		Name = groupitems.First().Field<string>("ChildRowName").ToString(),
                		items = from item in groupitems
                    	select new ChildList
                    	{
                    		Name = item["ChildColumnName"].ToString(),
                    		attributes = from op in ds.Tables[2].AsEnumerable()
                        		 where item["ChildId"] == op["ChildId"]
                        		 select new ChildListAttribute
                        		 {
                             Attribute1 = op["Attribute1"].ToString(),
                             Attribute2 = op["Attribute2"].ToString(),
                        		 }
                    	}
                	}
               };
