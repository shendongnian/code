    //Setting the max value for Piers and Moorings
        public const int mooringsPerPier = 5;
        public const int maxMoorings = 30;
        private static bool[] reserveMooring = new bool[maxMoorings];
    [WebMethod]
        public BoatResponse ReserveMooring(BoatRequest req)
        {
            for (int mooring = 0; mooring < maxMoorings; mooring++)
            {
                    if (!reserveMooring[mooring])
                    {
                        reserveMooring[mooring] = true;
                        return new BoatResponse()
                        {
                           Pier = (Pier)(int(mooring / mooringsPerPier)),
                           Mooring = (Mooring)(int(mooring % mooringsperPier)
                        };
                    }
                }
            }
            return null;
        }
