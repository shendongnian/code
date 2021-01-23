    interface IPaymentRequest
    {
        string Token { get; set; }
        int ClientID { get; set; }
        ITransaction Transaction { get; set; }
    }
