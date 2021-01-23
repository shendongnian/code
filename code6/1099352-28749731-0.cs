    using UnityEngine;
    using System.Collections;
    
    public class Paintser : PowerUp
    {
      public float normalSpeed = 10;
      public static int paintCount = 0;
      public int speedBoostTime = 3;
    
      public static void SpeedUp(){
    
          SimplePlayer0.speed = SimplePlayer0.speed * 2;
          Paintser.paintCount = Paintser.paintCount = 0;
          StartCoroutine("duringBoost");
        }
    
        private Enumerator duringBoost(){
           yield return new WaitForSeconds(speedBoostTime);
           SimplePlayer0.speed = normalSpeed;
         }
    
      }
    }
