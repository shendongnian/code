    public void Disable(int customerId) {
        var customer = _customerRepository.Get(customerId);
        customer.Disable();
        _customerRepository.SaveDisable(customer);
    }
