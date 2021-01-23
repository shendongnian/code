    private async void FormRegion1_FormRegionShowing(object sender, System.EventArgs e)
    {   
            if (this.OutlookItem is Microsoft.Office.Interop.Outlook.MailItem)
            {
                Microsoft.Office.Interop.Outlook.MailItem item = (Microsoft.Office.Interop.Outlook.MailItem)this.OutlookItem;
                pictureBox1.Visible = true;
                var contact = GetContactByEmailAsync(item);
	            if (contact != null)
	            {
	                lblName.Text = contact.Name;
	                lblMobile.Text = contact.Phone;
	            }
	
	            pictureBox1.Visible = false;
            }
    }
    public async Task<SimpleContact> GetContactByEmailAsync(Microsoft.Office.Interop.Outlook.MailItem item)
    {
        using (var client = new System.Net.Http.HttpClient())
        {
            client.BaseAddress = new Uri("http://api.....");
            client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = await client.GetAsync(
				"tools/getContactByEmail?email=" + item.SenderEmailAddress + "&key=1232")
				.ConfigureAwait(false);
            return (response.IsSuccessStatusCode)
                ? await response.Content.ReadAsAsync<SimpleContact>();
                : null;
        }
    }
