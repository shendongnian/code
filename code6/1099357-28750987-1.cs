    public class Paintser : PowerUp
    {
    
      public static int paintCount = 0;
      public int speedBoostTime = 3;
    
      public static void SpeedUp()
      {
        if (paintCount == 4)
        {
    
          SimplePlayer0.SpeedUp();
    
          Paintser.paintCount = Paintser.paintCount = 0;
    
        }
      }
    }
