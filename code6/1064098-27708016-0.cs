    public class ElectricSensor : Sensor
    {
       public ElectricSensor(IMethodCaller caller): base(caller)
       {
       }
       public void CommunicationStart()
       {
          base.Caller.CallMethodByKey("START_COMMON");
          base.Caller.CallMethodByKey("INITIALIZE_ELECTRIC");
       }
      // (...) 
    }
