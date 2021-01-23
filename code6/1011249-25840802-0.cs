    public class AccessRight
        {
    
            public string FormName { get; set; }
            public int CanView { get; set; }
        }
    
        public void ApplySecurity() 
        {
            // --- 
            if (dtDBRoleControl.Rows.Count > 0)
            {
                // first loop through your database rows. 
                // create a small POCO to perform actions.
    			List<AccessRight> accessRights = new List<AccessRight>();
    			foreach(var drmaster in dtDBRoleControl.Rows){
    				var access = new AccessRight() { FormName = drmaster["rprevformname"].ToString(), CanView = Convert.ToInt32(drmaster["rprevview"]) };
    				accessRights.Add(access);
    			}
    
                // close your database here...
    			
    			
    		
    
                // now for each menu call a method as given below
    
                PerformActionOnMenu(masterToolStripMenuItem, accessRights);
                PerformActionOnMenu(servicesToolStripMenuItem, accessRights);
                PerformActionOnMenu(reportsToolStripMenuItem, accessRights);
                PerformActionOnMenu(maintenanceToolStripMenuItem, accessRights);
    
    
            }
        }
    
        private void PerformActionOnMenu(ToolStripMenuItem menuItem , List<AccessRight> accessRights)
        {
           	var result = from item in menuItem.DropDownItems
    					     where item.Tag != null && item.Tag.ToString()
    						 join x in accessRights on x.FormName.Equals( item.Tag) 
    						 select new { DropDownItem = item, Access = x};
    
    			if ( result != null && result.Count() > 0 ) 
    			{	
    				menuItem.Visible = true;		
    				foreach(var r in results ){
    					 r.DropDownItem.Visible = true;
    				}
    			}
        }
