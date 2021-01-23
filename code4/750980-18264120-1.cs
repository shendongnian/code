    class Trip
    {
        public int DistanceTraveled { get; set; }
        public double CostGas { get; set; }
        public int NumberGallon { get; set; }
        public int MilesPerGallon { get { return (NumberGallon != 0) ? DistanceTraveled / NumberGallon : 0; } }
        public double CostPerMile { get { return CostGas * MilesPerGallon; } }
        public Trip()
        {
            DistanceTraveled = 312;
            CostGas = 3.46;
            NumberGallon = 10;
        }
        public override string ToString()
        {
            return String.Format("The distance traveled is...{0} \nThe cost per gallon of gasoline is... {1} \nThe amount of gallons were... {2} \nThe miles per gallon attained were... {3} \nThe cost per MPG were... {4}", DistanceTraveled, CostGas, NumberGallon, MilesPerGallon, CostPerMile);
        }
    }
