     void Contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
        {
        
                List<CustomContact> listOfContact = new List<CustomContact>();
                foreach (var c in e.Results)
                {
                    
                    CustomContact contact = new CustomContact();
                    contact.Name = c.DisplayName;
                    int count = c.PhoneNumbers.Count();
                    for (int i = 0; i < count; i++)
                    {
                       
                        if (count > 0)
                        {
                        
                        numbers.Add (c.PhoneNumbers.ElementAt(i).PhoneNumber.ToString());
                    }
          
                    }
                    listOfContact.Add(contact);
                }
                ContactResultsData.ItemsSource = listOfContact;
            
            if (ContactResultsData.Items.Any())
            {
                ContactResultsLabel.Text = "results";
            }
            else
            {
                ContactResultsLabel.Text = "no results";
            }
        }
