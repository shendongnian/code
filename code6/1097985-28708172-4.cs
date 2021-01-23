    //Application service (runs in a transaction)
    public void Disable(int customerId) {
        var customer = this.customerRepository.FindById(customerId);
        customer.Disable(); //execute business logic
        this.customerRepository.Save(customer); //persist the state
    }
