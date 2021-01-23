        [Flags]
        public enum TheirEnum
        {
            GEOTHERMAL=1,
            SOLAR_HEATING=2,
            NO_INFORMATION=4
        }
        [Flags]
        public enum OurEnum
        {
            Geothermal=TheirEnum.GEOTHERMAL,
            SolarHeating=TheirEnum.SOLAR_HEATING,
            NoInformation=TheirEnum.NO_INFORMATION
        }
