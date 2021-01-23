    public class A
    {
        A(IDataReceiver instanceOfClassB)
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
    public B : Form, IDataReceiver
    {
         public void ReceiveData(string data)
         {
              textBox.Append(data + Environment.NewLine);
         }
    }
    public interface IDataReceiver
    {
        void ReceiveData(string data);
    }
