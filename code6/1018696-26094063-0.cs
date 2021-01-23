    public class Wall
    {
        int X,Y,W,H;
        
        //Define an event, add a listener to this, becuase we will fire this when there is a collision
        public event EventHandler OnCollision;
        public void CollisionCheck(Ball playerBall)
        {
           //1 Check for a collision with the "Ball" object
           if(Ball.Rectangle().Intersects(this.Rectangle))
             this.OnCollision(this, EventArgs.Empty); //Fire the event, null check might be requried
        }
    }
