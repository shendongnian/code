    public class Bullets : List<Bullet>
    {
        // methods to help manage your bullets to taste
        // might be useful
         public void MoveAllBullets()
         {
            foreach (var bullet in this)
            {
               bullet.Move();
            }
         }
    }
