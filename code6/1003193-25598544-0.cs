     [XmlIgnore]
        public double[][] MyJaggedArr { get; set; }
        [XmlIgnore]
        public double[][] MyJaggedArr2 { get; set; }
        [XmlElement("myJaggedArr")]
        public List<double> MyJaggedArrList
        {
            get { return MyJaggedArrList; }
            set { MyJaggedArrList = MyJaggedArr.SelectMany(T => T).ToList(); }
        }
        [XmlElement("myJaggedArr2")]
        public List<double> MyJaggedArr2List
        {
            get { return MyJaggedArr2List; }
            set { MyJaggedArrList = MyJaggedArr2.SelectMany(T => T).ToList(); }
        }
