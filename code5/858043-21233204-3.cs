    public static class FormHelper
    {
        public static UpdateCustomerInfo(ICustomerForm form, Customer customer)
        {
            form.Name = customer.Name;
            form.Address = customer.Address;
        }
    }
