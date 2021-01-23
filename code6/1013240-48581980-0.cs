    private void ComboBoxChange(object sender, TextChangedEventArgs e)
		{
            //Clear ComboBox items
			CMB_ClientName.Items.Clear();
            //Auto Open DropDownList
			CMB_ClientName.IsDropDownOpen = true;
            //Get data from database (use entity framework 6.x)
			dbEntity.Client.Load();
            //Attribute Data to variable
			var clients = dbEntity.Client.Local;
            
			foreach (Client client in clients)
			{
				//If data begin with the texbox text, the data is add to the combobox items list.
                if (client.Nom.ToLower().StartsWith(TXT_NomClient.Text.ToLower()))
				{
					CMB_ClientName.Items.Add(client.Nom);
				}
			}
		}
