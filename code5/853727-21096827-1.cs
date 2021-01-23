    public class Visits
    {
        private DateTime _dischargeDate;
        
        public DateTime? DischargeDate
        {
            get {
                return _dischargeDate;
            }
            set
            {
                if (value == null)
                {
                    this._dischargeDate = DateTime.MinValue;
                }
                else
                {
                    this._dischargeDate = value.Value;
                }
            }
        }
    }
