    public class EnemyManager
    {
       List<Shark> activeSharks = new List<Shark>();
       Timer spawnTimer;
    
       //Just one random instance per class, this is considered best practice to improve
       //the randomness of the generated numbers
       Random rng = new Random(); //Don't use a specific seed, that reduces randomness!
    
       public EnemyManager()
       {
          //Min/max time for the next enemy to appear, in milliseconds
          spawnTimer = new Timer(rng.Next(500, 2000));
          spawnTimer.Elapsed += SpawnShark;
          spawnTimer.Start();
       }
    
       public void SpawnShark(object sender, ElapasedEventArgs e)
       {
           Vector2 newSharkPosition = Vector2.Zero;
           newSharkPosition.X = rng.Next(0, 1280); //Whatever parameters you want    
           newSharkPosition.Y = rng.Next(0, 1280); //Whatever parameters you want    
    
           Vector2 newSharkDirection.... //Repeat above for direction
    
           Shark spawnedShark = new Shark(newSharkPosition, newSharkDirection);
           activeSharks.Add(spawnedShark);
    
           //Min/max time for the next enemy to appear, in milliseconds
          spawnTimer = new Timer(rng.Next(500, 2000));
       }
    
       public void update(GameTime gameTime)
       {
          foreach(Shark s in activeSharks)
            s.Update(gameTime);
       }
    
       public void draw(SpriteBatch spritebatch, Texture2D wave)
       {
          foreach(Shark s in activeSharks)
            s.Draw(spritebatch, wave)
       }
    }
    
    public class Shark
    {
        Vector2 position;
        Vector2 direction;
        const float speed = 3;
        const int height = 44;
        const int width = 64;
    
        public Shark(Vector3 initPosition, Vector3 direction)
        {
            position = initPosition;
            this.direction = direction;
        }
    
        //Draw/Update using the local variables.
    }
