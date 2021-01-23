    private class PlayerRequest : IPlayerRequest
    {
        //hard code your test values you are passing in
        public string Name {get; private set;}
        public PlayerRequest() {
             Name = "MockName";
        }
    }
