    internal interface ICalculator
    {
        double Calculate(params double[] values);
    }
    internal class BmiCalculator : ICalculator
    {
        /// <summary>
        /// </summary>
        /// <param name="values">Mass, height</param>
        /// <returns></returns>
        public double Calculate(params double[] values)
        {
            if (values == null) throw new ArgumentNullException("values");
            if (values.Length < 2) throw new ArgumentOutOfRangeException("values");
            double mass = values[0];
            double height = values[1];
            return mass / (Math.Pow(height, 2.0d));
        }
    }
    public class FuelConsumptionCalculator : ICalculator
    {
        /// <summary>
        /// </summary>
        /// <param name="values">Litres, per kilometers, distance</param>
        /// <returns></returns>
        public double Calculate(params double[] values)
        {
            if (values == null) throw new ArgumentNullException("values");
            if (values.Length < 3) throw new ArgumentOutOfRangeException("values");
            double liters = values[0];
            double perKilometers = values[1];
            double distance = values[2];
            return (liters * perKilometers) / distance;
        }
    }
