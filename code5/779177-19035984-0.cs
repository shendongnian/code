    public class ShipSub : SomeBaseClass
    {
        private MainGame game;
        public ShipSub(MainGame game, String reference, int x, int y)
            : base(game, reference, x, y)
        {
            this.game = game;
        }
    }
