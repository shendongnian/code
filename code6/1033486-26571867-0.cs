    class Estudante
    {
        public string primeironome { get; set; }
        public string segundonome { get; set; }
        public int[] notas { get; set; }
        public string StringNotas
        {
           get 
             {
                return string.Join(",", notas);
             }
       }
    }
