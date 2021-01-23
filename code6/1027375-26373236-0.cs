            public static void cifrar()
        {
            Console.WriteLine("Escribe el mensaje");
            string letra = Console.ReadLine();
            letras l = (letras)Enum.Parse(typeof(letras), letra);
            int di = ((int)l) + 5;
            if (di > 53) di = ((int)l) - 49; 
            Console.WriteLine("Cifrado: " + ((letras)di));
            Console.ReadLine();
        }
        public static void descifrar()
        {
            Console.WriteLine("Escribe el cifrado");
            string letra = Console.ReadLine(); ;
            letras l = (letras)Enum.Parse(typeof(letras), letra);
            int di = ((int)l) - 5; 
            if (di < 0) di = ((int)l) + 49; 
            Console.WriteLine("Descifrado: " + ((letras)di));
            Console.ReadLine();
        } 
        
