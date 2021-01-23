    namespace Hangman
    {
        class Program
        {
        static void Main(string[] args)
        {
            string oracion;
            char letra_insertada;
            int aciertos = 5;
            int contador = 0;
            Console.WriteLine("Bienvenido al juego del ahorcado. ");
            Console.Write("Primer Jugador introduzca la palabra secreta: ");
            oracion = Console.ReadLine();
            Char[] oracionChar = oracion.ToCharArray();
            Console.WriteLine("Segundo Jugador ya puede empezar a jugar.");
            foreach( char letra in oracionChar)
            {
                Console.Write(" _ "); 
            }
            Console.WriteLine("\n");
            Console.WriteLine("{0} desaciertos mas le son permitidos. \n",aciertos); //lives
            Char[] letracorrecta = new Char[oracionChar.Length];
            for (int i = 0; i < oracionChar.Length; i++)
            {
                letracorrecta[i] = '_'; 
            }
            while (aciertos > 0)
            {
                Console.Write("\n\nQue letra desea jugar : ");
                letra_insertada = Convert.ToChar(Console.ReadLine());
                bool ContainsWord = false;
                for (int j = 0; j < oracionChar.Length; j++)
                {
                    if (oracionChar[j] == letra_insertada)
                    {
                        letracorrecta[j] = letra_insertada; //inserting the correct word
                        ContainsWord = true;
                    }
                }       
                if (!ContainsWord)
                {
                  aciertos -= 1;
                }
                printWord(letracorrecta);
            }
        Console.ReadKey();
        }
        public static void printWord(char[] letracorrecta)
        {
            for (int j = 0; j < letracorrecta.Length; j++)
            {
                Console.Write(letracorrecta[j]);
            }
        }
    }
    }
