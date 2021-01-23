    class MyClass
    {
      
        public int valueOfCard{get;set;}
        public string specialCards{get;set;}
        public string suit{get;set;}
            
        //here your constructors.
        public Cards(int data, string typeIEking, string suitIEspades)
        {
            valueOfCard = data;
            specialCards = typeIEking;
            suit = suitIEspades;
        }
        public Cards(int data, string suitIEspades)
        {
            valueOfCard = data;
            specialCards = null;
            suit = suitIEspades;
        }
    }
