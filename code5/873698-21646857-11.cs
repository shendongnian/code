    void Contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
    {
        try
        {
            //We are using only the first contact.
            Contact con = e.Results.First();
    
            BitmapImage img = new BitmapImage();
            img.SetSource(con.GetPicture());
            Picture.Source = img;
        }
        catch (Exception)
        {
            //We can't get a picture of the contact.
        }
    }
