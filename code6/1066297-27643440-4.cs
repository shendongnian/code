    // A class like this might help you better manage your bullets
    public class Bullets : List<Bullet>
    {
        // methods to help manage your bullets to taste
        // might be useful
        // Ie go to place to move all bullets
        public void MoveAllBullets()
        {
           foreach (var bullet in this)
           {
              bullet.Move();
           }
        }
    }
