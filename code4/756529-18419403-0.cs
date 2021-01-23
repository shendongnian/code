    public class OtherStrategy : Base_strategy { }
    titfortat_strategy ts = null;
    
    
    static public void compare(ref Base_strategy player1, ref Base_strategy player2)
    {
        player1 = new OtherStrategy();
    }
