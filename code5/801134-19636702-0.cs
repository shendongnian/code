    using System;
    using System.Collections.Generic;
    using System.Drawing;
    namespace Demo
    {
        class Program
        {
            private void run()
            {
                test1(Color.Red);
                test1(Color.Green);
                test1(Color.FromArgb(0xea, 0x36, 0xbe));
                test1(Color.FromArgb(0x24, 0x67, 0xc0));
                test2(Color.Red);
                test2(Color.Green);
                test2(Color.FromArgb(0xea, 0x36, 0xbe));
                test2(Color.FromArgb(0x24, 0x67, 0xc0));
            }
            private void test1(Color colour)
            {
                switch (colour.Name)
                {
                    case "Red":
                    {
                        Console.WriteLine("Red");
                        break;
                    }
                    case "Green":
                    {
                        Console.WriteLine("Green");
                        break;
                    }
                    case "ffea36be":
                    {
                        Console.WriteLine("My custom colour");
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Unknown colour: " + colour.Name);
                        break;
                    }
                }
            }
            private void test2(Color colour)
            {
                Action action;
                if (_colourMapper.Value.TryGetValue(colour, out action))
                    action();
                else
                    Console.WriteLine("Unknown colour: " + colour.Name);
            }
            private static Dictionary<Color, Action> createColourMapper()
            {
                var result = new Dictionary<Color, Action>();
                result[Color.Red] =                        () => Console.WriteLine("Red");
                result[Color.Green] =                      () => Console.WriteLine("Green");
                result[Color.FromArgb(0xea, 0x36, 0xbe)] = () => Console.WriteLine("My custom colour");
                return result;
            }
            private readonly Lazy<Dictionary<Color, Action>> _colourMapper = new Lazy<Dictionary<Color, Action>>(createColourMapper);
            static void Main(string[] args)
            {
                new Program().run();
            }
        }
    }
