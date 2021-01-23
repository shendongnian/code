    class Example
    {
        
        public static void Main(string[] args)
        {
            SeatType c = SeatType.AnythingExceptSeatNearBathroom;
            Console.WriteLine(c.Description);
            Console.WriteLine(SeatType.AnythingExceptSeatNearBathroom == c);
            foreach (SeatType seat in SeatType.GetEnumMembers())
            {
                Console.WriteLine(String.Format("Seat type code: {0} - description: {1}",seat.Code,seat.Description));
            }
            Console.ReadLine();
        }
    }
