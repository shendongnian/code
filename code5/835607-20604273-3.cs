    protected void ddlState_SelectedIndexChanged(object sender, EventArgs, e)
    {
        //hide all the panels 
        for(int i=0;i<ddlState.Items.Count;i++)
        {
           var control= ddlState.Items[i].Value;
          if(this.FindControl(control)!=null)
               this.FindControl(control).Visible=false;
        }
        //show the selected dropdown list panel
    	string item = Dropdownlist1.SelectedValue;
        if(this.FindControl(item)!=null)
    	   this.FindControl(item).Visible =true;
        
    }
