    List<Test> test = new List<Test> {
              new Test { Name ="ABC",FirstAmount =10,SecondAmount =20}
                     };
    public class Test
    {
        public String Name {set;get;}
        public decimal FirstAmount {set;get;}
        public decimal SecondAmount {set;get;}
        public decimal TotalAmount {get {return FirstAmount + SecondAmount;}}
    }
