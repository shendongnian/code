    using UnityEngine;
    using System.Collections;
    
    public interface IMover {
    
         float Move();
    
    }
    
    public class Move_1 : IMover {
    
        private Vector2 vec;
        private Rigidbody2D rb;
        public float moveSpeed = 1;
        public float energyConsumption = 0.1;
 
        public Move_1(Vector2 vec,Rigidbody2D rb){
            this.vec = vec;
            this.rb = rb;
        }
    
        float Move(){
            this.rb.AddForce (this.vec * moveSpeed);
            return energyConsumption * vec.magnitude;
        }
    
    }
