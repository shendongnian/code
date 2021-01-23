      public Start_New_Game()
      {
         bool FoundAll = false;
         int i;
         Player MyPlayer;
         MyPlayer = new Player();
         Hiders[] MyHiders = new Hiders[ 4 ];
         HiderGenerator hiderGenerator = new HiderGenerator();
    
         for ( i = 0 ; i < 4 ; i++ )
         {
            MyHiders[ i ] = hiderGenerator.Get_New_Hider();
         }
    
         while ( FoundAll == false )
         {
            MyPlayer.Move();
            for ( i = 0 ; i < 4 ; i++ )
            {
               MyHiders[ i ].DisplayDistance( MyPlayer.x, MyPlayer.y );
            }
            for ( i = 0 ; i < 4 ; i++ )
            {
               MyHiders[ i ].CheckCapture( MyPlayer.x, MyPlayer.y );
            }
    
            FoundAll = true;
            for ( i = 0 ; i < 4 ; i++ )
            {
               if ( MyHiders[ i ].Found == false )
               {
                  FoundAll = false;
               }
            }
         }
         Console.WriteLine( "You Win!" );
      }
    
      class Player
      {
         public int x;
         public int y;
    
         public void Move()
         {
            string buffer;
            Console.WriteLine( "Where would you like to move?" );
            buffer = Console.ReadLine();
            if ( buffer == "u" )
            {
               x++;
            }
            if ( buffer == "d" )
            {
               x--;
            }
            if ( buffer == "l" )
            {
               y--;
            }
            if ( buffer == "r" )
            {
               y++;
            }
         }
      }
    
      class HiderGenerator
      { 
         Random MyRandom = new Random();
         public Hiders Get_New_Hider()
         {
            return new Hiders( MyRandom.Next(1,10), MyRandom.Next(1,10) );
         }
      }
    
      class Hiders
      {
         private int x;
         private int y;
    
         public bool Found;
         int[,] map = new int[ 10, 10 ];
    
         public Hiders( int x, int y )
         {
            this.x = x;
            this.y = y;
         }
    
         public void DisplayDistance( int px, int py )
         {
            if ( Found )
               return;
    
            double distance;
    
            distance = Math.Sqrt( Math.Pow( x - px, 2 ) + Math.Pow( y - py, 2 ) );
    
            Console.WriteLine( distance );
         }
    
         public void CheckCapture( int px, int py )
         {
            if ( Found )
               return;
    
            if ( x == px && y == py )
            {
               Found = true;
            }
         }
      }
