     public enum Operation
    {
        [DA.Services.ResponseType (Type = ResponseType.CreateOrder)]
        CreateOrder,
        [DA.Services.ResponseType(Type = ResponseType.GetAddressbooks)]
        GetAddressbooks,
        [DA.Services.ResponseType(Type = ResponseType.GetCatalogItems)]
        GetCatalogItems,
        [DA.Services.ResponseType(Type = ResponseType.GetAddressbookAssociations)]
        GetAddressbookAssociations,
        [DA.Services.ResponseType(Type = ResponseType.GetBudgets)]
        GetBudgets,
        [DA.Services.ResponseType(Type = ResponseType.GetUDCTable)]
        GetUDCTable
    }
    class ResponseType : System.Attribute
    {
        public string Type { get; set; }
        public const string CreateOrder = "Models.Order";
        public const string GetAddressbooks = "Models.AddressbookRecord";
        public const string GetCatalogItems = "Models.Item";
        public const string GetAddressbookAssociations = "Models.AddressbookAssociation";
        public const string GetBudgets = "Models.Budget";
        public const string GetUDCTable = "Models.UdcTable";
    }
