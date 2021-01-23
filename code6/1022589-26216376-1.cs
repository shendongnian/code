    void Main()
    {
        var repository = new Repository();
        //Find all
        repository.FindAll().Dump();
        // Find by mail
        var mail = new Func<Customer, IComparable>(customer =>
        {
            return Tuple.Create(customer.Mail);
        });
        repository
            .FindByCriteria(mail)
            .Dump();
        // Find by mail and card number
        var multi = new Func<Customer, IComparable>(customer =>
        {
            return Tuple.Create(customer.CardNumber, customer.Mail);
        });
        repository
            .FindByCriteria(multi)
            .Dump();
    }
