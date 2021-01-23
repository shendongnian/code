        private void dequeueButton_Click(object sender, EventArgs e)
        {
            if (customers.Count != 0)
            {
                customers.Dequeue();
                customerQueueListView.Items[0].Remove();
            }
        }
