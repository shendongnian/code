    public interface IMovement
    {
        int speed { get; set; }
    }
    
    public class Worker
    {
        speed = 5;
        IMovement Movement;
       public Warrior(IMovement m)
        {
            this.Movement = m;
        }
        public void Move()
        {
          this.Movement.Move();
        }
    }
    
    public class Warrior
    {
        speed = 3;
        IMovement movement;
    
        public Warrior(IMovement m)
        {
            this.Movement = m;
        }
    
        public void Move()
        {
          this.Movement.Move();
        }
    }
    
    void foo()
    {
         IMovement m = new FlyingMovement();
         Worker w = new Worker(m);
    
        IMovement swimmingMovement = new SwimmingMovement();
         SwimmingWorker sw = new SwimmingWorker (swimmingMovement);
    }
