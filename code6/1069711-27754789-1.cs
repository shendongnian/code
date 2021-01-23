    [DataContract]
    public class Player
    {
        .
        .
        .
        [OperationContract]
        public override string ToString()
        {
            return UserName;
        }
