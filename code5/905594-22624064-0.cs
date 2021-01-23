    public class MyViewModel
    {
        public List<Customer> Customers { get; set; }
        public Customer SelectedCustomer { get; set; }
        public void BindingSourceCurrentChanged(object sender, EventArgs e)
        {
            var bindingSource = sender as BindingSource;
            if (bindingSource == null) return;
            SelectedCustomer = bindingSource.Current as Customer;
        }
    }
