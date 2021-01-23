    public class StuffObject{
        ....
        private decimal sumValue;
        private decimal description;
        public string Description {
            get{
                return string.Format("{0:C2}<br/>{1:C2}", sumvalue,description);
            }
        }
        ....
    }
