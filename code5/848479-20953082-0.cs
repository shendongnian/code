    private void PickupForm_Load(object sender, EventArgs e)
    {
        if(thePickup == null)
        {
            thePickup = new Pickup();
        }
        if(theDelivery == null)
        {
            theDelivery = new Delivery();
        }
        if(theVisit == null)
        {
            theVisit =  new Visit();
        }
        
        textCname.Text = thePickup.PickupName;
        textAddress.Text = thePickup.PickupAddress;
        textDate.Text = theVisit.DateTime.ToString();
        textDname.Text = theDelivery.DeliveryName;
        textDaddress.Text = theDelivery.DeliveryAddress;   
    }
