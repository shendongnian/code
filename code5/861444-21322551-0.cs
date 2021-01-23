    class YourModel {
        public int QandAID { get; set; }
        public string ValidityClass {
            get {
                return QandAID == 1 ? "correct" : "incorrect";
            }
        }
    }
