    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
    public class MyService:IMyService
    {
        int m_Counter = 0;
        public int MyMethod()
        {
            m_Counter++;
            return m_Counter;
        }       
    }
