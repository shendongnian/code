     DateTime RandomDay()
        {
            DateTime start = new DateTime(1900, 1, 1);
            Random gen = new Random();
        
            int range = (DateTime.Today - start).Days;           
            return start.AddDays(gen.Next(range));
        }
