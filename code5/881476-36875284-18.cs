    namespace WebApplication1.Models {
    
    	public enum GoodMusic {
    		Metal,
    		HeavyMetal,
    		PowerMetal,
    		BlackMetal,
    		ThashMetal,
    		DeathMetal // . . .
    	}
    
    	public class Fan {
    		[Required(ErrorMessage = "Don't be shy!")]
    		public String Name { get; set; }
    		[Required(ErrorMessage = "There's enough good music here for you to chose!")]
    		public GoodMusic FavouriteMusic { get; set; }
    	}
    }
