    public class StuffObject{
        ....
        private decimal sumValue;
        private string description;
        public string Description {
            get{
                return string.Format("{0:C2}<br/>{1}", sumvalue,description);
            }
        }
        ....
    }
