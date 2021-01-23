        static void Main(string[] args)
        {
            var seatToUse = "A1";
            var items = typeof (SeatsList).GetProperties().ToList();
            foreach (var item in items)
            {
                if (item.Name == seatToUse)
                {
                    Console.WriteLine("Match");
                }else{
                    Console.WriteLine("Does not match");
                }
            }
            Console.ReadKey();
        }
    }
    public class SeatsList
    {
        public int A1 { get; set; }
        public int A2 { get; set; }
        public int B1 { get; set; }
        public int B2 { get; set; }
    }
