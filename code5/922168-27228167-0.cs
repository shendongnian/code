    namespace Mastermind_2._0
        {
        class Program
        {
            static void Main(string[] args)
            {
               
                
                string A;//Navigation im Hauptmenü.
                string B;//Navigation in der Anleitung.
                string C;//Navigation im Spiel Menü.
                string D;//Navigation am Ende des Spieles vs. Freund bei Sieg.
                string E;//Navigation am Ende des Spieles vs. Freund bei Verlust.
                string F;//Navigation am Ende des Spieles vs. Computer bei Verlust.
                string G;//Navigation am Ende des Spieles vs. Computer bei Sieg.
                string Eingabe_Spieler1;//Freund vs. Freund string Eingabe.
                string Tipp;//Eingabe des Tippes von Spieler #2.
                int length;//Länge der Eingabe des Spieler #1.
                int Versuch = 0;//Anzahl der Versuche von Spieler #2, Default = 1, weil Spieler #2 auch beim ersten mal richtig liegen könnte.
                int Versuch_C= 1;
                int i;//Enumerator für den for- Loop. 
                int b;//-"-
                int correct = 0;//Zahl für die Anzahl an Richtigen. Bei correct = 8 -> Gewonnen.
                int correct_C= 0;// -"-
                char[] Möglichkeiten = { 'R', 'B', 'P', 'V', 'G', 'O' };//Array für die möglichen Farbkombinationen.
                
                //Hauptmenü.
                Menü:
                Console.WriteLine("\n----------------------------Willkommen zu Mastermind----------------------------");
                Console.WriteLine("\n                             [A]nleitung                                        ");
                Console.WriteLine("                             [S]pielen                                          ");
                Console.WriteLine("                             [B]eenden                                          ");
                Console.WriteLine("--------------------------------------------------------------------------------");
                //Die Variable A in einen string konvertieren.
                try
                {
                    A = Convert.ToString(Console.ReadKey(true).KeyChar);
                }
    
                catch (System.ApplicationException e)
                {
                    Console.WriteLine(e.Message);
                    goto Menü;
                }
    
                catch (System.OverflowException e)
                {
                    Console.WriteLine(e.Message);
                    goto Menü;
                }
    
                catch (System.FormatException e)
                {
                    Console.WriteLine(e.Message);
                    goto Menü;
                }
                //Die Methode .toUpper() anwenden. hallo wird zu HALLO.
                A = A.ToUpper();
                //switch -case statement anwenden als Kontrollstruktur (default).
                switch (A)
                {
                    case "A":
                        //Anleitung besteht aus einer Zeile wegen der Übersicht.
                        Console.WriteLine("\n------------------------------------Anleitung-----------------------------------");
                        Console.WriteLine("\nWillkommen zu Mastermind. In diesem Spiel geht es darum deinen Freund oder\nden Computer zu besiegen. Dein Freund oder der Computer generiert einen\nFarbcode, der aus den Farben [R]ot [B]lau [P]ink [V]iolett [G]elb [O]range\nbestehen kann. Man hat 7 Versuche um den Farbcode zu erraten. Wenn man es\nnicht schafft gewinnt der Gegenspieler. Bei einem Versuch wird eine Farbe\nan der richtigen Stelle durch 'schwarz' gekennzeichnet. Bei einer richtigen\nFarbe, die jedoch an der falschen Stelle liegt kommt 'weiß'. Bei einer fal-\nschen Farbe kommt das Stichwort 'nichts'. Viel Spaß beim Spielen!");
                        //Zurück navigieren.
                        Console.WriteLine("\n--------------------------------------------------------------------------------");
                        Console.WriteLine("[Z]urück");
                        Console.WriteLine("[S]pielen");
                        Console.WriteLine("[B]eenden");
                        B = Convert.ToString(Console.ReadKey(true).KeyChar);
                        B = B.ToUpper();
                        //Wenn B Z ist gehe zurück zu dem Menü.
                        if (B == "Z") {
                            goto Menü;
                        }
                        //Wenn B S ist gehe zu dem Abschnitt Spiel.
                        if (B == "S") {
                            goto Spiel;
                        }
                        //Wenn B, B ist beende das Programm.
                        if (B == "B")
                        {
                            Console.WriteLine("Bye...");
                            for (i = 1; i < 40; i++)
                            {
                                Console.SetWindowSize(i, i);
                                System.Threading.Thread.Sleep(50);
                            }
    
                            Environment.Exit(0);    
                        }
                        //Kontrollstruktur.
                        if(B != "Z" || B != "S" || B != "B"){
                            Console.WriteLine("Ich verstehe das nicht...");
                            goto Menü;
                        }
                        break;
                    case "S":
                        goto Spiel;
                    case "B":
                        Console.WriteLine("Bye...");
                        
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ich verstehe das nicht...");
                        goto Menü;
                }
                //Spiel Menü mit einem case- statement.
            Spiel:
                Versuch = 1;
                Console.WriteLine("\n------------------------------------Spiel Menü----------------------------------");
                Console.WriteLine("\n--                         Gegen wen möchten sie spielen?                     --");
                Console.WriteLine("\n--                         vs. [C]omputer                                     --");
                Console.WriteLine("\n--                         vs. [F]reund                                       --");
                Console.WriteLine("\n--                         Zurück zum [H]auptmenü                             --");
                Console.WriteLine("\n--                         Zurück zum [S]pielmenü                             --");
                Console.WriteLine("\n--                         [B]eenden                                          --");
                Console.WriteLine("\n--------------------------------------------------------------------------------");
                //Die Variable C in einen string konvertieren.
                C = Convert.ToString(Console.ReadKey(true).KeyChar);
                //Die Methode .toUpper() anwenden. hallo wird zu HALLO.
                C = C.ToUpper();
                //switch -case statement anwenden als Kontrollstruktur (default).
                switch (C)
                {
                    //Gegen einen Computer spielen.
                    case "C":
                        //Arrays erstellen
                    string Tipp_C ="Default";
                    char[] Farben_array = { 'R', 'B', 'P', 'V', 'G', 'O' };
                    //leerer Array, der gefüllt wird
                    char[] Computer_array = { ' ', ' ', ' ', ' ' };
                    //Farbkombination erstellen
                    Random rnd = new Random();
                    int n = 0;
                    do
                    {
                        //Eine zufällige Nummer von 0 bis 5.
                        int rand = rnd.Next(0, 5);
                        //Die Position n (n erhöht sich um 1) ist gleich dem Objekt an Position "rand"
                        Computer_array[n] = Farben_array[rand];
                        n += 1;
                    }
                    //Tue das solange n kleiner als 4 ist.
                    while (n < 4);
                
                    //Menü
                    Console.WriteLine("\nDer Code vom Computer wurde generiert...");
                    do
                    {
                        //Zurück zum Menü
                        Console.WriteLine("\nSpieler 2: {0}. Versuch.", Versuch_C);
                        Console.WriteLine("\nEs gibt die Farben 'R', 'B', 'P', 'V', 'G'und 'O'");
                        try
                        {
                            Tipp_C = Convert.ToString(Console.ReadLine());
                            bool contains = Tipp_C.Contains("1234567890");
                            if (contains == false) {
                                throw new System.ApplicationException("Der Tipp darf keine Zahlen beinhalten!");
                            }
                        }
                  
                        catch (ApplicationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        //Tipp_C .Contains in Farben_array
                        char[] Tipp_C_array = Tipp_C.ToCharArray();
                        correct_C = 0;
                        for (b = 0; b < 4; b++)
                        {
                            if (Tipp_C_array[b] == Computer_array[b])
                            {
                                correct_C += 2;
                                Console.WriteLine("Black");
                            }
                            bool contains = Computer_array.Contains<char>(Tipp_C_array[b]);
                            if (contains == true && Tipp_C_array[b] != Computer_array[b])
                            {
                                correct_C += 1;
                                Console.WriteLine("White");
                            }
                            if (contains != true && Tipp_C_array[b] != Computer_array[b])
                            {
                                Console.WriteLine("None");
                                correct_C += 0;
                            }
                        }
                        b = 0;
                        Versuch_C += 1;
                        if (correct_C == 8)
                        {
    
                            Console.WriteLine("\n--        Herzlichen Glückwunsch du hast es beim {0}. Versuch geschafft.        --", Versuch_C);
                            Console.WriteLine("\n--                          Zurück zum [H]auptmenü                            --");
                            Console.WriteLine("\n--                          Zurück zum [S]piel Menü                           --");
                            Console.WriteLine("\n--                          [B]eenden                                         --");
                            Console.WriteLine("\n--------------------------------------------------------------------------------");
                            Versuch_C = 1;
                            G = Convert.ToString(Console.ReadKey(true).KeyChar);
                            //Die Methode .toUpper() anwenden. hallo wird zu HALLO.
                            G = G.ToUpper();
                            //switch -case statement anwenden als Kontrollstruktur (default).
                            if (G == "S")
                            {
                                goto Spiel;
                            }
                            if (G == "H")
                            {
                                goto Menü;
                            }
                            if (G == "B")
                            {
                                Environment.Exit(0);
                            }
                            if (G != "S" || G != "B" || G != "H")
                            {
                                Console.WriteLine("Ich verstehe nicht...");
                                goto Spiel;
                            } 
                        }
                    }
                    while (Versuch_C != 8);
                    Versuch_C = 1;
                    Console.WriteLine("\n--                   Du hast es leider nicht geschafft...                     --", Versuch_C);
                            Console.WriteLine("\n--                          Zurück zum [H]auptmenü                            --");
                            Console.WriteLine("\n--                          Zurück zum [S]piel Menü                           --");
                            Console.WriteLine("\n--                          [B]eenden                                         --");
                            Console.WriteLine("\n--------------------------------------------------------------------------------");
                            F = Convert.ToString(Console.ReadKey(true).KeyChar);
                            //Die Methode .toUpper() anwenden. hallo wird zu HALLO.
                            F = F.ToUpper();
                            //switch -case statement anwenden als Kontrollstruktur (default).
                            if (F == "S")
                            {
                                goto Spiel;
                            }
                            if (F == "H")
                            {
                                goto Menü;
                            }
                            if (F == "B")
                            {
                                Environment.Exit(0);
                            }
                            if (F != "S" || F != "B" || F != "H")
                            {
                                Console.WriteLine("Ich verstehe nicht...");
                                goto Spiel;
                            } break;
                                    //Gegen einen Freund spielen.
                    case "F":
                        Console.WriteLine("\n\n\n\n\n\n\n-----------------Spieler 1: Bitte wähle deine Farbcombination.------------------");
                        Console.WriteLine("\n-- Diese kann aus [R]ot [B]lau [P]ink [V]iolett [G]elb oder [O]range bestehen --");
                        Console.WriteLine("\n--                Beispiel: BRVG                                              --");
                        Console.WriteLine("\n--                Dies würde Blau, Rot, Violett, Gelb bedeuten.               --");
                        Console.WriteLine("\n--------------------------------------------------------------------------------");
                        Console.WriteLine("\nFarbcombination:");
                        Eingabe_Spieler1 = Convert.ToString(Console.ReadLine());
                        length = Eingabe_Spieler1.Length;
                        //Kontrollstruktur. Hier die 2. hinzufügen
                        if (length != 4) {
                            goto case "F";
                        }
                    Console.Clear();
                    //do -while loop für das Vergleichen der arrays
                    do
                    {
    
                        Console.WriteLine("Spieler 2: {0}. Versuch.", Versuch);
                        Console.WriteLine("\nEs gibt die Farben 'R', 'B', 'P', 'V', 'G'und 'O'");
                        Tipp = Convert.ToString(Console.ReadLine());
                        //Tipp oder Eingabe Spieler #2 werden in einen char Array aufgebrochen
                        char[] Tipp_Array = Tipp.ToCharArray();
                        //Eingabe von Spieler #1 wird aufgebrochen in einen char Array
                        char[] Eingabe_Spieler1_Array = Eingabe_Spieler1.ToCharArray();
                        correct = 0; //Den integer correct auf 0 zurücksetzen
                        //Integer i um einen erhöhen. 0, 1, 2, 3. Jedes mal wird die Position gewechselt. Die Arrays werden verglichen in den folgenden Zeilen.
                        for (i = 0; i < 4; i++)
                        {
                            //Bei der richtigen Position und richtigen Farbe wird zu der Variabel correct 2 hinzugefügt.
                            if (Tipp_Array[i] == Eingabe_Spieler1_Array[i])
                            {
                                correct += 2;
                                Console.WriteLine("Schwarz");
                            }
                            //Boolean der entscheidet ob es einen weißen Stift gibt. Wenn contains richtig ist aber es die falsche Position hat gibt es einen weißen Stift. 
                            bool contains = Eingabe_Spieler1_Array.Contains<char>(Tipp_Array[i]);
                            if (contains == true && Tipp_Array[i] != Eingabe_Spieler1_Array[i])
                            {
                                //Correct erhöht sich um 1. 
                                correct += 1;
                                Console.WriteLine("Weiß");
                            }
                            //Wenn es die falsche Position ist und die Farbe nicht vorhanden ist gibt es keinen Stift.
                            if (contains != true && Tipp_Array[i] != Eingabe_Spieler1_Array[i])
                            {
                                Console.WriteLine("Nichts");
                                //Correct wir um 0 erhöht.
                                correct += 0;
                            }
                        }
    
                        i = 0;
                        Versuch += 1;
    
                        //Wenn correct 8 ist, d.h. dass 4 mal schwarz kam wird die Schleife beendet mit break; und man hat gewonnen
                        if (correct == 8)
                        {
                            Versuch -= 1;
                            Console.WriteLine("\n--        Herzlichen Glückwunsch du hast es beim {0}. Versuch geschafft.        --", Versuch);
                            Console.WriteLine("\n--                          Zurück zum [H]auptmenü                            --");
                            Console.WriteLine("\n--                          Zurück zum [S]piel Menü                           --");
                            Console.WriteLine("\n--                          [B]eenden                                         --");
                            Console.WriteLine("\n--------------------------------------------------------------------------------");
                            D = Convert.ToString(Console.ReadKey(true).KeyChar);
                            //Die Methode .toUpper() anwenden. hallo wird zu HALLO.
                            D = D.ToUpper();
                            //switch -case statement anwenden als Kontrollstruktur (default).
                            if (D == "S")
                            {
                                goto Spiel;
                            }
                            if (D == "H")
                            {
                                goto Menü;
                            }
                            if (D == "B")
                            {
                                Environment.Exit(0);
                            }
                            if (D != "S" || D != "B" || D != "H")
                            {
                                Console.WriteLine("Ich verstehe nicht...");
                                goto Spiel;
                            } break;
                        }
                    }
                    //Solange Versuch nicht 8 ist wird diese Schleife wiederholt und wiederholt.
                    while (Versuch != 8);
                    Versuch = 1;
                    Console.WriteLine("\n--                   Du hast es leider nicht geschafft...                     --", Versuch);
                            Console.WriteLine("\n--                          Zurück zum [H]auptmenü                            --");
                            Console.WriteLine("\n--                          Zurück zum [S]piel Menü                           --");
                            Console.WriteLine("\n--                          [B]eenden                                         --");
                            Console.WriteLine("\n--------------------------------------------------------------------------------");
                            E = Convert.ToString(Console.ReadKey(true).KeyChar);
                            //Die Methode .toUpper() anwenden. hallo wird zu HALLO.
                            E = E.ToUpper();
                            //switch -case statement anwenden als Kontrollstruktur (default).
                            if (E == "S")
                            {
                                goto Spiel;
                            }
                            if (E == "H")
                            {
                                goto Menü;
                            }
                            if (E == "B")
                            {
                                Environment.Exit(0);
                            }
                            if (E != "S" || E != "B" || E != "H")
                            {
                                Console.WriteLine("Ich verstehe nicht...");
                                goto Spiel;
                            } break;
                    case "H":
                        goto Menü;
                    case "S":
                        goto Spiel;
                    case "B":
                        Console.WriteLine("Bye...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ich verstehe das nicht...");
                        goto Spiel;
          }
        }
      }
    }
