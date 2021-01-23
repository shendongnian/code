    public void  resetBindings() 
     {
      foreach (Control c in Form1.Controls)
           
                c.DataBindings.Clear();
                bindingFields();
     }
     public void  bindingFields() 
      {
        txtCode.DataBindings.Add("Text",theVehicule,"vhCode");
          ...
          ..
        txtActifInactif.DataBindings.Add("EditValue", theVehicule, "vhInactif");
      }
    private void barBtnSaveNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
        this.Validate();
        theVehicule.Save();
        theVehicule = new tbVehicule(theVehicule.Session);
        resetBindings();
       }
