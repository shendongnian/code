    public interface IResturant
    {
       IMenu Menu {get;}
    }
    
    public interface IMenu
    {
       Dictionary<string,double> MenuItems{get;}
    }
    
    public class BurgerKingMenu : IMenu
    {
       // Menu items will contain the whole Burger King menu
    }
    
    public class KFCMenu : IMenu
    {
       // Menu items will contain the whole KFC menu
    }
    
    public class KFCResturant : IResturant
    {
       // will get KFC's IMenu
    }
    
    public class BurgerKingReturant : IResturant
    {
       // will get Burger King's IMenu
    }
