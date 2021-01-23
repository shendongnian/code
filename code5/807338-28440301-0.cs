    public static CustomerMVC FromCustomerWebAPI(CustomerWebAPI customer){
        return new CustomerMVC(){
            CustomerName = customer.CustomerName,
            CustomerCity = customer.CustomerCity
        }
    }
