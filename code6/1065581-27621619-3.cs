    class Player
    {
        // Other subclasses, and properties.
        public static Player CreatePlayer()
        {
            // Note how I created the instance variables for the player class,
            // and I used a notation called "object initalizer" to set those properties
            // when I create the Player instance.
            var p = new Player.int2();
            var v = new Player.float2();
            Player player = new Player()
            {
              velocity = v,
              Position = p
            };
            return player;
        }
    }
