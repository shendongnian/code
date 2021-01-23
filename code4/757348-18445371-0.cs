    if (Session["beachBach"] != null)
    {
        beachBachLabel.Text = numberOfBeachBookingInteger.ToString();
        numberOfBeachBookingInteger += 1;
    }
    if (Session["beachBach"] != null)
    {
        bushBachLabel.Text = numberOfBushBookingInteger.ToString();
        numberOfBushBookingInteger += 1;
    }
