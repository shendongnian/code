    [Export]
    public sealed class PlayerViewModelFactory : IPlayerViewModelFactory
    {
        [Import]
        private ILoggerFacade Logger { get; set; }
        public IPlayerViewModel Create(IPlayer player)
        {
            switch (player.Sport)
            {
                case Sport.Basketball:
                    return new BasketballViewModel(Logger, player);
                case Sport.Football:
                    return new FootballViewModel(Logger, player);
                // etc...
                default:
                    throw new ArgumentOutOfRangeException("player");
            }
        }
    }
