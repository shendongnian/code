        public class Facility
        {
            private string _facilityName;
            private int _facilityID;
    
            public string FacilityName
            {
                get
                {
                    if (_facilityName == null)
                        return String.Empty;
                    else
                        return _facilityName;
                }
                set { _facilityName = value; }
            }
    
            public int FacilityID
            {
                get { return _facilityID; }
                set { _facilityID = value};
            }
        }
