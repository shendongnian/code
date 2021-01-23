    void RemoveControls()
        {
        HyperLink l1 = (HyperLink)Page.FindControl("hlLink"); 
        Literal l2 = (Literal)Page.FindControl("litSummary"); 
        
        
        if(l1!= null)
            Page.Controls.Remove(l1);
        
        if(l2!= null)
            Page.Controls.Remove(l2);        
        }
