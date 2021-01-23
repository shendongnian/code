    class Trip
    {
        int distanceTraveled;
        double costGas;
        int numberGallon;
        int mpg;
        double cpm;
        public int DistanceTraveled
        {
            get
            {
                return distanceTraveled;
            }
        }
        public double CostGas
        {
            get
            {
                return costGas;
            }
        }
        public int NumberGallon
        {
            get
            {
                return numberGallon;
            }
        }
        public Trip()
        {
            distanceTraveled = 312;
            costGas = 3.46;
            numberGallon = 10;
            mpg = milesPerGal();
            cpm = costPerMile();
        }
        public int milesPerGal()
        {
            return distanceTraveled / numberGallon;
        }
        public double costPerMile()
        {
            return costGas * mpg;
        }
        public override string ToString()
        {
            return String.Format("The distance traveled is...{0} \nThe cost per gallon of gasoline is... {1} \nThe amount of gallons were... {2} \nThe miles per gallon attained were... {3} \nThe cost per MPG were... {4}", distanceTraveled, costGas, numberGallon, mpg, cpm);
        }
    }
