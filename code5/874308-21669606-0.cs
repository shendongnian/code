    namespace Game
    {
        public class Program
        {
            static Program myProgram = new Program();
            Unit fighter;
    
            Texture textureFighter;
            static void MouseButtonPressed(object sender, MouseButtonEventArgs e)
            {
                if (e.Button == Mouse.Button.Left)
                {
                    myProgram.fighter.Move(new Vector2f(Mouse.GetPosition().X, Mouse.GetPosition().Y));
                }          
            }
            public static void Main()
            {
               myProgram.textureFighter = new Texture(@"resources\ship_fighter.png");
    
               myProgram.fighter = new Unit(new Vector2f(100, 100), 0)
                {
                    Texture = myProgram.textureFighter
                };
                ...
            }
    
        }
    }
