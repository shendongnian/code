    public class PartyClass
    {
        private object _partyTimeLock = new Object();  // executed at class init
        private boolean partyTime= true;
        public bool IsPartyGoingOn()
        {
           bool itIsGoingOn = false;
           lock(_partyTimeLock) {
              itIsGoingOn = partyTime;
           }
           return itIsGoingOn;
        }
        public void StopParty()
        {
            lock(_partyTimeLock) {
               partyTime = false;
            }
        }
        public void MakeParty()
        {
             while(IsPartyGoingOn()) {
                  Console.WriteLine("I'm making a party here");
             }
 
             Console.WriteLine("The party ended. Please leave now");
        }
    }
