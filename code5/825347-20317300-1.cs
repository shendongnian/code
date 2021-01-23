    protected void btnAddBike_Click(object sender, EventArgs e)
    {
        int g;
        if(!Int32.TryParse(Gears.Text, out g))
        {
            // some label where you could write the error message
            // labelError.Text = "An integer number is required.....";
            return;
        }
        BikeBinding b = new BikeBinding {
            manufacturer = Manufacturer.Text,
            gears = g,
            frame = Frame.Text
        };
        bicycles.Add(b);
        .....
