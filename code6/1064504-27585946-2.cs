     interface IState
     {
          void TakeDamage(float);
          ....
     }
     class WalkingState : IState
     {
          ActiveObject parent;
          public WalkingState(ActiveObject parent) { this.parent = parent;}
          public void TakeDamage(float) 
          {
              // do whatever needed including calling parent.XXX methods  
              ....
          }
          ...
     }
     
     class ActiveObject
     { 
         IState currentState;
         
         public void SetWalk () { currentState = new WalkState(this);}
         
         public TakeDamage(float damage)
         {
            currentState.TakeDamage(damage);
         }
         ...
     }
