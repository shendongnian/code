    //Setting the max value for Piers and Moorings
        public const int mooringsPerPier = 5;
        public const int maxMoorings = 30;
        private staticbool[] reserveMooring = new bool[maxMoorings];
    [WebMethod]
        public BoatResponse ReserveMooring(BoatRequest req)
        {
            int mooring = Array.IndexOf(reserveMooring, false);
            if (mooring < 0)
            {
              return null;
            }
            reserveMooring[mooring] = true;
            return new BoatResponse()
            {
               Pier = (Pier)(int(mooring / mooringsPerPier)),
               Mooring = (Mooring)(int(mooring % mooringsperPier)
            };
        }
