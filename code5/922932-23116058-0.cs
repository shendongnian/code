    class Rocket
    {
        int _life;
        public Rocket(Vector2 position, Vector2 direction)
        {
            _position = position;
            _direction = direction;
            //life of rocket. Once it reaches zero the rocket is removed.
            _life = 100;
        }
        Vector2 _position
        public Vector2 Position
        {
            get
            {
                return _position;
            }
        }
        Vector2 _velocity;
        Vector2 Velocity
        {
            get
            {
                return _velocity;
            }
        }
        public int Life
        {
            get
            {
                return _life;
            }
        }
        public void Update(World world)
        {
            _life--;
            _position += _velocity;
            //could check for collisions here, eg:
            foreach (Ship ship in world.Ships)
            {
                if (Intersects(ship))
                {
                    //collision!
                    //destroy this rocket
                    _life = 0;
                    //damage the ship the rocket hit
                    ship.ApplyDamage(10);
                    return;
               }
            }
        }
    }
    class Game
    {
        List<Rocket> _rockets = new List<Rocket>();
        List<Rocket> _deadRockets = new List<Rocket>();
        void Update(GameTime gameTime)
        {
            //.ToArray() is used here because the .net list does not allow items to be removed while iterating over it in a loop. 
            //But we want to remove rockets when they are dead. So .ToArray() means we are looping over the array not the 
            //list, so that means we are free to remove items from the list. basically it's a hack to make things simpler...
            foreach (Rocket rocket in _rockets.ToArray())
            {
                //world is an object that contains references to everything on the map
                //so that the rocket has access to that stuff as part of it's update
                rocket.Update( world );
                //if the rocket has run out of life then remove it from the list
                if (rocket.Life <= 0)
                    _rockets.Remove(rocket);
            }
        }
        void FireRocket(Vector2 from, Vector2 direction)
        {
            Rocket newRocket = new Rocket(from, direction);
            _rockets.Add(newRocket);
        }
    }
