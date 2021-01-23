    public class Measurement
    {
        private double measuredRadius = 0.0;
        public double MeasuredRadius { get { return measuredRadius; } set { measuredRadius = value; } }
        public double MeasuredThickness
        {
            get
            {
                var measurementValuesWithCurrentRadius = MeasurementValues.Where(x => x.Position.X == MeasuredRadius);
                var measuredDistances = measurementValuesWithCurrentRadius.Select(x => (DISTANCE_BETWEEN_SENSORS - x.DistanceFromSensor1 - x.DistanceFromSensor2));
                return measuredDistances.Average();
            }
        }
        private ObservableCollection<DistanceMeasurementsResults> measurementValues;
        public ObservableCollection<DistanceMeasurementsResults> MeasurementValues { get { return measurementValues; } }
    }
