        class ManagerAccessPoint
        {
             public void Receive (Action action)
             {
                 //where CallContractMethod is an abstract/virtual method
                 //which serves as a contract and now via run time polymorphism
                 //the appropriate action method will be called.
                 //Each and every child class will have different behavior of this action.
                 action.CallContractMethod();
             }
        }
