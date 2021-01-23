    public void ProcessTileEvent()
    {
        if( Player.X >= 0 && Player.X < 4 && Player.Y >= 0 && Player.Y < 4  )
        {
            switch( GameboardArray[Player.X, Player.Y] )
            {
                case "G":
                Console.WriteLine( "You found gold!" );
                break;
                case "P":
                Console.WriteLine( "You fell in a pit!" );
                break;
            }
        }
    }
