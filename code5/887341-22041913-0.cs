    if (response.IsSuccessStatusCode)
    {
        SimpleContact contact = await response.Content.ReadAsAsync<SimpleContact>();
        if (contact != null)
        {
          lblName.Text = contact.Name;
          lblMobile.Text = contact.Phone;
        }
                  
       pictureBox1.Visible = false;
    }
