            private void btnSave_Click(object sender, EventArgs e)
        {
            var customerResource = GetViewModel();
            if (ModelState.IsValid<CustomerResource>(customerResource)) {
            }
        }
        private CustomerResource GetViewModel() {
            return new CustomerResource() {
                CustomerName = txtName.Text,
                Phone = txtPhone.Text
            };
        }
