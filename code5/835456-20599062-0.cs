     class Draw
     {
        private Random draw = new Random();
        private List<Ticket> ticketContainer = new List<Ticket>();
        private List<Prize> prizes = new List<Prize>();
    
        public Prize DoDraw()
        {
            int ticketCount = ticketContainer.Count;
    
            int ticketNumber = draw.Next(1, ticketCount + 1);
            var result = prizes[ticketNumber];
            prizes[ticketNumber] = prizes[prizes.Count - 1]; // Put last element in the returned elements place
            prizes.RemoveAt(prizes.Length - 1);
            return result;
        }
