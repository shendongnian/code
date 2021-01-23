    [HttpPost]
    public async Task<ActionResult> Ipn()
    {
        var ipn = Request.Form.AllKeys.ToDictionary(k => k, k => Request[k]);
        ipn.Add("cmd", "_notify-validate");
    
        var isIpnValid = await ValidateIpnAsync(ipn);
        if (isIpnValid)
        {
            // process the IPN
        }
        
        return new EmptyResult();
    }
    
    private static async Task<bool> ValidateIpnAsync(IEnumerable<KeyValuePair<string, string>> ipn)
    {
        using (var client = new HttpClient())
        {
            const string PayPalUrl = "https://www.paypal.com/cgi-bin/webscr";
    
            // This is necessary in order for PayPal to not resend the IPN.
            await client.PostAsync(PayPalUrl, new StringContent(string.Empty));
    
            var response = await client.PostAsync(PayPalUrl, new FormUrlEncodedContent(ipn));
    
            var responseString = await response.Content.ReadAsStringAsync();
            return (responseString == "VERIFIED");
        }
    }
