    [ServiceContract] // No use of the 'Name' property
    public ISave<T> where T : BusinessObject
    {
        [OperationContract(Name="Save")]
        void Save(T obj);
    }
    public class SaveCustomer : ISave<Customer>
    {
        public void Save(Customer obj) { /* Do stuff here */ }
    }
