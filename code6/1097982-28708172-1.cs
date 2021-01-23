    //Application service (runs in a transaction)
    public void Disable(int customerId) {
        var customer = this.customerRepository.findById(customerId);
        customer.disable(); //execute business logic
        this.customerRepository.save(customer); //persist the state
    }
