         void Contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
                {
            		try
            		{
            		 List<CustomContact> listOfContact = new List<CustomContact>();
                      foreach (var c in e.Results)
                        {  
                               
                            int count = c.PhoneNumbers.Count();
                            for (int i = 0; i < count; i++)
                             {
                                CustomContact contact = new CustomContact();
                                contact.Name = c.DisplayName;
                                contact.Number = c.PhoneNumbers.ElementAt(i).PhoneNumber.ToString();
                                listOfContact.Add(contact);
                            }
                        }
                     ContactResultsData.ItemsSource = listOfContact;
            		}
                    
            	   catch (System.Exception)
                   {
                      //No results
                   }
        
                   if (ContactResultsData.Items.Any())
                   {
                        ContactResultsLabel.Text = "results";
                   }
                   else
                   {
                        ContactResultsLabel.Text = "no results";
                   }
                }
    
