    public class SignalRAbstraction : IAbstraction 
    {
    
        public SignalRAbstraction(IConnectionManager connectionManager) 
        {
           var hubContext = connectionManager.GetHubContext<GameRoomHub>();
        }
     
    }
