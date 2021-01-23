    public class SystemData
    {
        private double _ratedVoltage;
        private double _actualVoltage;
        #region ctor
        internal SystemData(
            double systemBaseMva,
            double ratedVoltage,
            double actualVoltage)
        {
            SystemBaseMVA = systemBaseMva;
            _ratedVoltage = ratedVoltage;
            _actualVoltage = actualVoltage;
        }
        #endregion
        #region Properties
        [DataMember]
        public double SystemBaseMVA { get; private set; }
        [DataMember]
        public Dictionary<Variant, double> Voltage
        {
            get
            {
                return new Dictionary<Variant, double>
                {
                    {Variant.Rated, _ratedVoltage},
                    {Variant.Actual, _actualVoltage}
                };
            }
            private set
            {
                double itemValue;
                if (value.TryGetValue(Variant.Rated, out itemValue))
                    _ratedVoltage = itemValue;
                if (value.TryGetValue(Variant.Actual, out itemValue))
                    _actualVoltage = itemValue;
            }
        }
        #endregion
    }
