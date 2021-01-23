    private void btnSendSms_Click(object sender, RoutedEventArgs e)
    {
        var info = await GetCurrentCoordinate();
        if (info.Item1 != nuil)
        {
            lblLatitude.Text = info.Item1.Latitude.ToString("0.000");
            lblLongitude.Text = info.Item1.Longitude.ToString("0.000");
        }
        if (info.Item2 != null)
        {
            var address = info.Item2.Information.Address;
            lblCurrAddress.Text = string.Format(
                "{0} {1},\n{2} {3},\n{4} ({5})",
                 address.Street,
                 address.HouseNumber,
                 address.PostalCode,
                 address.City,
                 address.Country,
                 address.CountryCode);
        }
        SendSms(info.Item1, info.Item2);
    }
