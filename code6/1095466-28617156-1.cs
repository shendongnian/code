    public class A
    {
        A(MyInerface instanceOfClassB)
        {
              //stuff...
        }
    
        public void SendProcessedString()
        {
             //some strings has been processd, I know that class B is going
             //to have a public method like ReceiveData(string data){/*---*/}
             instanceOfClassB.ReceiveData(data);
        }
    }
