    in update button click 
      string id = string.Empty;
            string itmcod = string.Empty;
            try
            {
                foreach (DataListItem item in DataListSearchResult.Items)
                {
                    CheckBox chk = (CheckBox)item.FindControl("chkActive");
                    HiddenField ShowcaseID = (HiddenField)item.FindControl("HdnShowcaseID");
    
                    if (chk.Checked==false)
                    {
                        id += ShowcaseID.Value +","; 
                    }            
                }
           //  Update the records with id  
            }
            catch
            { 
            
            }
