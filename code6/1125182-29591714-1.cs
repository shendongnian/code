    int eid = Convert.ToInt32(EstateComboBox.SelectedValue.ToString());
    var myEstate = AgencyContext.Estate.Single(e => e.EstateID == eid);
    
    myEstate.Available = false; //new value
   
    dbcontext.SaveChanges();
