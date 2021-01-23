    [Association(IsForeignKey=true, Name="FK_PhoneBook_Customers", Storage="customer", ThisKey="CustomerId", OtherKey = "Id")]
    public Customer Customer
    {
        get { return this.customer.Entity; }
        set { this.customer.Entity = value; }
    }
