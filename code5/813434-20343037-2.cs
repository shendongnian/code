    private void LoadBoat(int boatID)
    {
        using (var db = new MyMarinaEntities())
        {
            var boat = db.Boats.SingleOrDefault(b => (b.BoatID == boatID));
            this.chkIsRental.Checked = boat.IsRental;
            this.chkInactive.Checked = boat.Inactive;
            this.txtLength.Text = boat.Length;
            this.txtManufacturer = boat.Manufacturer;
            // ...
        }
    }
