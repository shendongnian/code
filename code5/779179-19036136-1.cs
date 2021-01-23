    public class ShipSub : BaseClass // Base class would be what you call `super()` on
    {
       private MainGame game;
     
       public ShipSub(MainGame mainGame, String reference, int x, int y) 
          : base(reference, x, y)
       {
          this.mainGame = game;
       }
    } 
