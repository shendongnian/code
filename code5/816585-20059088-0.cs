    public class sData
    {
        public string name;
        public int Number;
        public sData(string name,int Number)
        {
            this.poster_path = path; //copied from question, this might need updating.
            this.Number = Number;
        }
  
        sData CreateCopy()
        {
            return new sData(name, number);
        }
    }
    sData template = new sData("aaaa","0");
    
    sData realData1 = template.CreateCopy();
    realData1.Number=100;
