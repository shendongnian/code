    namespace SudokuTest
    {
        using System.Collections.Generic;
        using System.Runtime.Serialization;
        using System.ServiceModel;
        [ServiceContract]
        public interface ISudokuConcurrentService
        {
            [OperationContract]
            SudokuGame ClientConnect();
            [OperationContract]
            List<Player> GetListOfWinners(int SentScore, string _SentPlayerID);
        }
        [DataContract]
        public class SudokuGame
        {
            [DataMember]
            public string PlayerID { get; set; }
            [DataMember]
            public int TimeLimitInSeconds { get; set; }
        }
        [DataContract]
        public class Player
        {
            [DataMember]
            public string PlayerID { get; set; }
            [DataMember]
            public int Score { get; set; }
        }
    }
