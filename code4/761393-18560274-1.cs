    @{
        var db = Database.Open("QualityMonitoring") ;
        var listAgent = "SELECT Agent FROM Data";
    
        List<SelectListItem> agentdropdownlistdata = new List<SelectListItem>();
        bool isSelected = false;
        foreach(var item in db.Query(listAgent)){   
            agentdropdownlistdata.Add(new SelectList Item
            {
                Text = item.AgentName,
                Value = item.AgentID.ToString(), 
                Selected = isSelected
            });
        }
    }
