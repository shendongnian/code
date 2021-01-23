    namespace MyCashMachine
    {
            [ServiceContract(Namespace = "http://example.com/CashMachine")] //Note that this is the xmlns-namespace used in the WSDL/schema, not your endpoint.
            public interface ICashMachineService
            {
                [OperationContract]
                void GimmehMoniez(int howMuch);
                [OperationContract]
                boolean UHazMoniez();
                [OperationContract]
                int GetMoniezLeft();
            }
    }
