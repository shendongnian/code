            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.LeftArrow)
            {
                int levo = pozice;
                if (levo == 1) //Zajištění, že se nedosáhne hodnoty vyšší, než je rozsah pole  
                {
                    levo = levo + 1;
                }
                p18[levo - 1] = "*+*"; //Samotný posun panáčka
                p18[levo] = "   "; //Smazání panáčka z původní pozice
            }
            if (key == ConsoleKey.RightArrow)
            {
                int pravo = pozice;
                if (pravo == 18) //Zajištění, že se nedosáhne hodnoty vyšší, než je rozsah pole
                {
                    pravo = pravo - 1;
                }
                p18[pravo + 1] = "*+*"; //Samotný posun panáčka
                p18[pravo] = "   "; //Smazání panáčka z původní pozice
            }
