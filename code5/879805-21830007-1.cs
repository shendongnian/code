    public class PlayerService : Service
    {
        // Route 1 handled here
        public PlayerResponse Post(ChangePlayerNameRequest request)
        {
            return new PlayerResponse { Name = request.Name + " something else" };
        }
        // Route 2 handled here
        public PlayerResponse Post(ChangePlayerNameAndConcatRequest request)
        {
            return new PlayerResponse { Name = request.Name + " just a test"};
        }
    }
