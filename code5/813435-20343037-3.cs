    protected void btnSave_click(object sender, EventArgs args)
    {
        using (var dm = new MyMarinaEntities())
        {
            MyMarinaEntities boat;
            
            boat.IsRental = this.chkIsRental.Checked;
            boat.Inactive = this.chkInactive.Checked;
            boat.Length = this.txtLength.Text;
            boat.Manufacturer = this.txtManufacturer;
            // ...
            if (boatID.Value == "") 
                dm.AddObject("Boats", boat);
            dm.SaveChanges();
        }
    }
