        private static readonly IDictionary<string, string> MenuLinks = 
             new Dictionary<string, string>
        {
            {"add_client", "Add_Client.aspx"},
            {"delete_client", "Delete_client.aspx"},
            {"add_invoice", "add_purchinvoice.aspx"},
            {"add_invoice", "Add_sellinvoice.aspx"}, // *** Error!
            // ...
        };
        
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            string redirectLink;
            if (MenuLinks.TryGetValue(e.Item.Value, out redirectLink))
            {
                // Avoid the thread abort exception of a response.redirect by making sure this is the last action in the page lifecycle
                Response.Redirect(redirectLink, false);
            }
            else
            {
                txtErrorMessage.Text = "Please select a Link";
            }
        }   
