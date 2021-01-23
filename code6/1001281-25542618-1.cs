    interface ILivingGameObject
    {
        int Health {get;set;}
    }
    class Player : GameObject, ILivingGameObject
    {
    }
    
    void CheckHealth(ILivingGameObject obj)
    {
         if(obj.Health == 0)
              kill(obj);
    }
