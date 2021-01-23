        int count;
        Queue<Customer> customers = new Queue<Customer>();
        ListViewItem item;
        private void enqueueButton_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            count++;
            customer.serialNo += count;
            customer.name = nameTextBox.Text;
            customer.complain = complainTextBox.Text;
            customers.Enqueue(customer);
            foreach (Customer custm in customers)
            {
                item = new ListViewItem(custm.serialNo.ToString());
                item.SubItems.Add(custm.name);
                item.SubItems.Add(custm.complain);
            }
            customerQueueListView.Items.Add(item);            
        }
