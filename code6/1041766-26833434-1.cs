    using System.Collections.Generic;
    class Player{
        public int Number;
        public string LastName;
        public int Points;
    
        public ResetInfo(){
            Number=0;
            LastName="";
            Points=0;
        }
    }
    class PlayerManager{
        static Dictionary<int,Player> dctOfPlayers= new Dictionary<int, Player>();
        
        public static AddNewPlayer(Player newPlayer){
            dctOfPlayers.Add(newPlayer.Number,newPlayer);
        }
    
        public static RemovePlayer(int playerNumber){
            dctOfPlayers[layerNumber].ResetInfo();
        }
    }
