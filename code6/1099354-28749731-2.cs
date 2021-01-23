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
          StartCoroutine("duringBoost", speedBoostTime, normalSpeed);
        }
    
        private static IEnumerator duringBoost(int duration, int newSpeed){
           yield return new WaitForSeconds(duration);
           SimplePlayer0.speed = newSpeed;
         }
    
      }
    }
