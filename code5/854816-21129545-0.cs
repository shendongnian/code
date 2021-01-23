    public class YourModel {
        public string FuelType { get; set; }
        public int VehicleYear { get; set; }
        public string CatalystLabelText {
            get {
                return (this.FuelType == "D" &&
                       this.VehicleYear >= 2009) ? _resNMHCCatalyst : _resCatalyst;
            }
        }
    }
