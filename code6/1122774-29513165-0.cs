     public GameModel(ApplicationDbContext context, GameRoom room) : this(GlobalHost.ConnectionManager.GetHubContext<GameRoomHub>())
        {
            this.db = context;
            this.gameroom = room;
        }
