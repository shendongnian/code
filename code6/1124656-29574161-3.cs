    public class Game
    {
        const string RabbitIcon = "\u0150";   //  \u0150   \u014E    \u00D2     \u00D3 --> alternatives
        static readonly char[] MazeChars = { '─', '│', '┌', '┐', '└', '┘', '▼', '\u00B8', '┬', '┴', '├', '┤', '┼' };
        static readonly ConsoleColor MazeFgColor = ConsoleColor.DarkGray;
        enum Input
        {
            MoveLeft,
            MoveRight,
            MoveUp,
            MoveDown,
            Quit
        };
        public static void Run()
        {
            Console.WriteLine("Select Level (Available levels: 1,2):");
            Console.WriteLine("\n(\\_/)\n(o.o)\n(___)0\n");
            int carrotCounter = 0;
            int gameLevel = int.Parse(Console.ReadLine()); // by pressing a number the user can select different labyrinths.
            // Console Height and Width
            Console.WindowHeight = 25;
            Console.BufferHeight = Console.WindowHeight + 1; // +1 to allow writing last character in the screen corner
            Console.BufferWidth = Console.WindowWidth = 80;
            Console.OutputEncoding = System.Text.Encoding.Unicode;  // Must have this + Change font to Lucida in CMD
            
            // Reads maze map
            string[] mapRows = File.ReadAllLines(String.Format("game.level{0}.txt", gameLevel));
            if (!mapRows.All(r => r.Length == mapRows[0].Length))
                throw new InvalidDataException("Invalid map");
            var charMap = mapRows.Select(r => r.ToCharArray()).ToArray();
            // Draw maze & rabbit once 
            Console.CursorVisible = false;
            DrawLabyrinth(charMap);
            int rabbitX = 1, rabbitY = 1;
            DrawRabbit(rabbitX, rabbitY, RabbitIcon);
            // Game Loop:
            Input input;
            while ((input = GetInput()) != Input.Quit)
            {
                if (MoveRabbit(input, ref rabbitX, ref rabbitY, charMap) &&
                    IsPositionWithCarrot(rabbitX, rabbitY, charMap))
                    EatCarrot(rabbitX, rabbitY, charMap, ref carrotCounter);
            }
        }
        static void EatCarrot(int rabbitX, int rabbitY, char[][] theMap, ref int carrotCounter)
        {
            // determine carrot top position.
            var carrotTopY = theMap[rabbitY][rabbitX] == '7' ? rabbitY + 1 : rabbitY;
            // "eat it" from the map.
            theMap[carrotTopY][rabbitX] = ' ';
            theMap[carrotTopY + 1][rabbitX] = ' ';
            // and erase it on screen;
            Console.SetCursorPosition(rabbitX, carrotTopY);
            Console.Write(' ');
            Console.SetCursorPosition(rabbitX, carrotTopY + 1);
            Console.Write(' ');
            // redraw the rabbit
            carrotCounter++;
            DrawRabbit(rabbitX, rabbitY, RabbitIcon);
        }
        static Input GetInput()
        {
            while (true)
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        return Input.MoveLeft;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        return Input.MoveRight;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        return Input.MoveUp;
                    case ConsoleKey.DownArrow: 
                    case ConsoleKey.S:
                        return Input.MoveDown;
                    case ConsoleKey.Q:
                        return Input.Quit;
                    default:
                        break;
                }
            }
        }
        static bool IsValidRabbitPosition(int x, int y, char[][] theMap)
        {
            return x >= 0 && x < theMap[0].Length && y >= 0 && y < theMap.Length &&
                   (theMap[y][x] == ' ' || IsPositionWithCarrot(x, y, theMap));
        }
        static bool IsPositionWithCarrot(int x, int y, char[][] theMap)
        {
            return theMap[y][x] == '7' || theMap[y][x] == '8';
        }
        static void DrawRabbit(int x, int y, string rabbitIcon)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(rabbitIcon);
            Console.ResetColor();
        }
        static bool MoveRabbit(Input direction, ref int rabbitX, ref int rabbitY, char[][] theMap)
        {
            int newX = rabbitX, newY = rabbitY;
            switch (direction)
            {
                case Input.MoveLeft: newX--; break;
                case Input.MoveRight: newX++; break;
                case Input.MoveUp: newY--; break;
                case Input.MoveDown: newY++; break;
            }
            if (IsValidRabbitPosition(newX, newY, theMap) && (newX != rabbitX || newY != rabbitY))
            {
                DrawRabbit(rabbitX, rabbitY, " "); // erase
                rabbitX = newX;
                rabbitY = newY;
                DrawRabbit(rabbitX, rabbitY, RabbitIcon); // draw
                return true;
            }
            return false;
        }
        static void DrawLabyrinth(char[][] theMap)
        {
            Console.Clear();
            for (int y = 0; y < theMap.Length; y++)
            {
                Console.SetCursorPosition(0, y);
                for (int x = 0; x < theMap[0].Length; x++)
                {
                    var ndx = theMap[y][x] - '1';
                    var c = ndx >= 0 && ndx < MazeChars.Length 
                        ? MazeChars[ndx] 
                        : ' ';
                    Console.ForegroundColor = IsPositionWithCarrot(x, y, theMap)
                        ? ndx == 6 ? ConsoleColor.Red : ConsoleColor.Green
                        : MazeFgColor;
                    Console.Write(c);
                    Console.ResetColor();
                }
            }
            Console.WindowTop = 0; // scroll back up.
        }
    }
