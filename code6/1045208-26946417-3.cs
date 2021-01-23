    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication22
    {
        class Program
        {
            static void Main(string[] args)
            {
                do
                {
                    #region Main Menu
                    var m = new Menu() { Title = "MAIN MENU" };
                    m.Menus.Add(new MenuItem() { Title = "New Game", SelectedForegroundColor = ConsoleColor.Green });
                    m.Menus.Add(new MenuItem() { Title = "Load Game" });
                    m.Menus.Add(new MenuItem() { Title = "Exit Game", SelectedForegroundColor = ConsoleColor.Yellow });
                    var result = m.ShowAndWaitUserInput();
                    //Console.Write("selected was:" + result);
                    //Console.ReadLine();
                    #endregion
    
                    switch (result)
                    {
                        case 0:
                            #region // Jump to character creation
                            var m1 = new Menu() { Title = "CHARACTER CREATION" };
                            m1.Menus.Add(new MenuItem() { Title = "New Character" });
                            m1.Menus.Add(new MenuItem() { Title = "Load Character" });
                            m1.Menus.Add(new MenuItem() { Title = "Return" });
                            var result1 = m1.ShowAndWaitUserInput();
                            switch (result1)
                            {
                                case 0:
                                    #region // CREATE THE NEW CHARACTER
                                    Console.WriteLine("CREATE THE NEW CHARACTER");
                                    Console.ReadKey();
                                    #endregion
                                    break;
                                case 1:
                                    #region // LOAD CHARACTER
                                    Console.WriteLine("LOAD CHARACTER");
                                    Console.ReadKey();
                                    // Write your code here...
                                    #endregion
                                    break;
                                case 2:
                                    #region // DO ALMOST NOTHING: RETURNS TO PREVIOUS MENU
                                    #endregion
                                    break;
                            }
                            #endregion
                            break;
                        case 1:
                            #region // Load Game code...
                            Console.WriteLine("LOAD GAME");
                            Console.ReadKey();
                            // Write your code here...
                            #endregion
                            break;
                        case 2:
                            #region // EXIT GAME
                            #endregion
                            return;
                    }
    
                } while (true); // Main Menu
            }
        }
    
        public class MenuItem
        {
            public MenuItem()
            {
                this.SelectedForegroundColor = ConsoleColor.Yellow;
            }
            public string Title { get; set; }
    
            public ConsoleColor SelectedForegroundColor { get; set; }
        }
        public class Menu
        {
            public Menu()
            {
                this.Menus = new List<MenuItem>();
            }
            public string Title { get; set; }
            public List<MenuItem> Menus { get; set; }
    
            public int ShowAndWaitUserInput()
            {
                Console.CursorVisible = false;
    
                int selectedMenu = 0;
    
                do
                {
                    Console.Clear();
                    #region Display Menu and Sub-Menus
                    {
                        var i = 0;
                        // more at http://www.graphics.cornell.edu/~westin/misc/windows_charmap.html
                        Console.WriteLine(" ╔═══════════════════════════════════════════╗");
                        Console.WriteLine(" ║ ░ " + this.Title.ToUpper().PadRight(40).Substring(0, 40) + "║");
                        Console.WriteLine(" ╚═══════════════════════════════════════════╝");
                        Console.WriteLine("");
                        //var old_CB = Console.BackgroundColor;
                        var old_CF = Console.ForegroundColor;
    
                        foreach (var menu in Menus)
                        {
                            //Console.WriteLine("   New Game");
                            if (i == selectedMenu)
                            {
                                Console.ForegroundColor = menu.SelectedForegroundColor;
                                Console.Write("  >> ");
                            }
                            else
                            {
                                Console.ForegroundColor = old_CF;
                                Console.Write("     ");
                            }
                            Console.WriteLine(menu.Title);
    
                            i++;
                        }
                        Console.WriteLine("");
    
                        //Console.BackgroundColor = old_CB;
                        Console.ForegroundColor = old_CF;
                    }
                    #endregion
                    #region Get User Input
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey();
                        if (keyInfo.Key == ConsoleKey.UpArrow)
                        {
                            selectedMenu--;
                            if (selectedMenu < 0) selectedMenu = Menus.Count() - 1;
                        }
                        else if (keyInfo.Key == ConsoleKey.DownArrow)
                        {
                            selectedMenu++;
                            if (selectedMenu == Menus.Count()) selectedMenu = 0;
                        }
                        else if (keyInfo.Key == ConsoleKey.Enter)
                        {
                            return selectedMenu;
                        }
                    }
                    #endregion
                } while (true);
    
            }
    
        }
    }
