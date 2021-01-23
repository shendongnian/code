    namespace ConsoleGame
    {    
    class Ball {
        
        private static Ball _instance;
        
        private int _a = 10, _b = 10;
        private int _dx = 1, _dy = 1;
        private int _timer = 0;
        private int _milliseconds = 1000;
        
        private Ball() { }
        public static Ball Instance {
            get {
                if(_instance == null) {
                        _instance = new Ball();
                }
                return _instance;
            }
        }
        /// <summary>
        /// Move the ball on screen
        /// </summary>
        /// <param name="speed">The refresh/draw speed of the screen</param>
        public void Move(int speed) {
            if (_timer >= _milliseconds) {
                // Set the cursor position to the current location of the ball
                Console.SetCursorPosition(_a, _b);
                // Clear the ball from the screen
                Console.WriteLine(" ");
                _a += _dx;
                _b += _dy;
                // Set a new locatio for the ball
                Console.SetCursorPosition(_a, _b);
                // Draw the new ball location on screen
                Console.Write("*");
                if (_a > 77) _dx = -_dx;
                if (_a < 2) _dx = -_dx;
                if (_b > 22) _dy = -_dy;
                if (_b < 2) _dy = -_dy;
            } else {
                _timer = _timer + speed;
            }
        }
    }
    class Paddle {
        
        private int _x = 2, _y = 23, _da = 1;
        public int x {
            get {
                if (_x > (Console.BufferWidth - "~~~~~~~~~~".Length)) x = -_da;
                if (_x < 2) x = -_da;
                if (_x < 0) x = 2;
                return _x; 
            }
            set { _x = value; }
        }
        private static Paddle _instance;
        
        private Paddle() { }
        
        public static Paddle Instance {
            get {
                if (_instance == null) {
                    _instance = new Paddle();
                }
                return _instance;
            }
        }
        /// <summary>
        /// Move the Paddle on screen
        /// </summary>
        /// <param name="direction">Direction to move the paddle (Left = -1, Right = 1, Do Not Move = 0)</param>
        public void Move(int direction) {
            Console.SetCursorPosition(x, _y);
            Console.Write("          ");
            x = x - direction;
            Console.SetCursorPosition(x, _y);
            Console.Write("~~~~~~~~~~");
        }
    }
    class Program {
        private static int PaddleDirection = 0;
        static void Main(string[] args) {
            
            Thread ConsoleKeyListener = new Thread(new ThreadStart(ListerKeyBoardEvent));
            ConsoleKeyListener.Name = "KeyListener";
            ConsoleKeyListener.Start();
            //ConsoleKeyListener.IsBackground = true;
            int speed = 50;
            do {
                
                Console.Clear();
                Ball.Instance.Move(speed);
                Paddle.Instance.Move(PaddleDirection);
                
                PaddleDirection = 0; // You can remove this line to make the paddle loop left/right on the screen after key press.
                
                Thread.Sleep(speed);
            } while (true);
        }
        private static void ListerKeyBoardEvent() {
            do {
                ConsoleKeyInfo k = Console.ReadKey(true);
                if (k.Key == ConsoleKey.LeftArrow) PaddleDirection = 1;
                else if (k.Key == ConsoleKey.RightArrow) PaddleDirection = -1;
                else PaddleDirection = 0;
                Console.ReadKey(false);
            } while (true);           
            
        }
    }
    }
