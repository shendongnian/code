            string blacklist = string.Empty;
            string blocked = string.Empty;
            if (radEnab.IsChecked == true)
            {
                blacklist = Convert.ToString(radEnab.DataContext);
            }
    
            if (radDis.IsChecked == true)
            {
                blacklist = Convert.ToString(radDis.DataContext);
            }
            if (radEnab2.IsChecked == true)
            {
                blocked = Convert.ToString(radEnab2.DataContext);
            }
    
            if (radDis2.IsChecked == true)
            {
                blocked = Convert.ToString(radDis2.DataContext);
            }
    
            string startDate = StartDate.Text;
            string expiryDate = ExpiryDate.Text;
            string zone = cboZone.Text;
    
          string data = cardId + cardType + cardPin + blacklist + blocked + startDate + expiryDate + zone;
          client.ReceiveDataFromApp("R1", "11", "161.100.100.79", "4000", data);
