    public static class MeterTypes
    {
        public static readonly Electricity electricity;
        public static readonly Gas gas;
        public static readonly Water water;
        static MeterTypes()
        {
            // initialize the meter types to their default
            MeterTypes.Water = Water.GenericWater;
            MeterTypes.Gas = Gas.GenericGas;
            MeterTypes.Electricity = Electricity.GenericElectricity;
        }
        private MeterTypes()
        {
            // private initialization prevents others from creating the class            
        }
        public class Electricity
        {
            public enum Type
            {
                Generic = 1007,
                SubsidisedElectricity = 1008,
                NonSubsidisedElectricity = 1009
            }
            public static readonly Electricity GenericElectricity;
            public static readonly Electricity SubsidisedElectricity;
            public static readonly Electricity NonSubsidisedElectricity;
            private Type ElectricityType;
            static Electricity()
            {
                SubsidisedElectricity = new Electricity(Type.SubsidisedElectricity);
                NonSubsidisedElectricity = new Electricity(Type.NonSubsidisedElectricity);
                GenericElectricity = new Electricity(Type.Generic);
            }
            // private constructor prevents creation from outside the class
            private Electricity(Type ElectricityType)
            {
                this.ElectricityType = ElectricityType;
            }
            public override string ToString()
            {
                return ElectricityType.ToString();
            }
            public string ToString(string format)
            {
                return ElectricityType.ToString(format);
            }
        }
        public class Gas
        {
            public enum Type
            {
                Generic = 1007,
                SubsidisedGas = 1008,
                NonSubsidisedGas = 1009
            }
            public static readonly Gas GenericGas;
            public static readonly Gas SubsidisedGas;
            public static readonly Gas NonSubsidisedGas;
            private Type gasType;
            static Gas()
            {
                SubsidisedGas = new Gas(Type.SubsidisedGas);
                NonSubsidisedGas = new Gas(Type.NonSubsidisedGas);
                GenericGas = new Gas(Type.Generic);
            }
            // private constructor prevents creation from outside the class
            private Gas(Type gasType)
            {
                this.gasType = gasType;
            }
            public override string ToString()
            {
                return gasType.ToString();
            }
            public string ToString(string format)
            {
                return gasType.ToString(format);
            }
        }
        public class Water
        {
            public enum Type
            {
                Generic = 1001,
                DrinkingWater = 1002,
                UsageWater = 1003
            }
            public static readonly Water GenericWater;
            public static readonly Water DrinkingWater;
            public static readonly Water UsageWater;
            private Type waterType;
            static Water()
            {
                DrinkingWater = new Water(Type.DrinkingWater);
                UsageWater = new Water(Type.UsageWater);
                GenericWater = new Water(Type.Generic);
            }
            // private constructor prevents creation from outside the class
            private Water(Type waterType)
            {
                this.waterType = waterType;
            }
            public override string ToString()
            {
                return waterType.ToString();
            }
            public string ToString(string format)
            {
                return waterType.ToString(format);
            }
        }
    }
