     private void onWorkflowActivated1_Invoked(object sender, ExternalDataEventArgs e)
        {
            //Currente item
            int item = onWorkflowActivated1.WorkflowProperties.ItemId;
            SPItem current =  onWorkflowActivated1.WorkflowProperties.Item;    
            //Get url from field
            SPFieldUrlValue fieldValue = new SPFieldUrlValue(current["Repository"].ToString());
            string linkTitle = fieldValue.Description;
            string linkUrl = fieldValue.Url;            
            string ruta = "Shared Documents/Folder"+item;
            using (SPSite site = new SPSite(linkUrl))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    web.Folders.Add(ruta);
                    workflowProperties.Item["Folder"] = linkUrl + ruta;                   
                    workflowProperties.Item.Update();  
                }
            }
          
        }
