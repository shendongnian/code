    public class Gate
    {
       void OnTriggerEnter(Collider other) 
       {
          GateKeeper.setPassedGateCount(this);
       }
    }
