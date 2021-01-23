    protected void MarkIncompleteList()
        {
            // remove the old items so the list is refreshed **************
            lbCurrentOrders.Items.Clear();
            // get a list of orders that are not complete for allerting
            List<string> iOrders = Data.GetIncomepletedOrders();
            lbOrderID.Text = "";
            List<string> ol = Data.GetOrdersList();
            foreach (string s in ol)
            {
                if (iOrders.Contains(s))
                {
                    lbCurrentOrders.Items.Add(s);
                    lbCurrentOrders.Items[lbCurrentOrders.Items.Count - 1].Attributes.Add("style", "color:red");
                }
                else
                    lbCurrentOrders.Items.Add(s);
            }
            
                
        }
