    class Program
    {
        static void Main(string[] args)
        {
            int counter; //Counter pro export
            int counterchyba;
            string strediska = "0003,0005"; 
            Sending(0, 0, strediska);                
        }
        public static void Sending(int counter, int counterchyba, string strediska)
        {
            var c = (counter).ToString().PadLeft(5, '0');
            SqlCommand cmd = new SqlCommand();
            .........
        }
     }
