        private subInfo1 _sub1;        
        [CategoryAttribute("SubInfo")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public subInfo1 SubInfo1
        {
            get { return _sub1; }
            set { _sub1 = value; }
        }
        private subInfo2 _sub2;
        [CategoryAttribute("SubInfo2")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public subInfo2 SubInfo2
        {
            get { return _sub2; }
            set { _sub2 = value; }
        }
