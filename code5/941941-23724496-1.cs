        public string getFoto(int number)
        {
            string line;
            using (var sr = new StreamReader("Fotodd.txt"))
            {
                line = sr.ReadLine();
            }
            string[] fotos;
            fotos = line.Split('|');
            return fotos[number - 1].Trim(); // String.Trim() removes whitespaces
        }
