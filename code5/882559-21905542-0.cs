      private void btnDonate_Click(object sender, System.EventArgs e)
        {
            string url = "";
        
            string business     = "my@paypalemail.com";  // your paypal email
            string description  = "Donation";            // '%20' represents a space. remember HTML!
            string country      = "AU";                  // AU, US, etc.
            string currency     = "AUD";                 // AUD, USD, etc.
        
            url += "https://www.paypal.com/cgi-bin/webscr" +
                "?cmd=" + "_donations" +
                "&business=" + business +
                "&lc=" + country +
                "&item_name=" + description +
                "&currency_code=" + currency +
                "&bn=" + "PP%2dDonationsBF";
        
            System.Diagnostics.Process.Start(url);
        }
