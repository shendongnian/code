    using UnityEngine;
    using System.Collections;
    
    public class Spikes : MonoBehaviour
    {
      private void ResolveDamage(Collision2D other){
        if (other.gameObject.tag == "player"){
          var player = other.gameObject.getComponent<SimplePlayer0>();
          if(!player.IsImmune){
            player.Lives--;  
          }
        }
      }
    
      void OnCollisionEnter2D(Collision2D other)
      {
        ResolveDamage(other);
      }
    
      void OnTriggerStay2D(Collider2D other)
      {
        ResolveDamage(other);
      }
    
      void OnCollisionStay2D(Collision2D other)
      {
       ResolveDamage(other);
      }
    }
