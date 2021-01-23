    class MyNumber
    {
        public int Number { get; set; }
        public static MyNumber operator +(MyNumber c1, MyNumber c2) 
        {
            //sum the .Number components and return them as a new MyNumber
            return new MyNumber{ Number = c1.Number + c2.Number };
        }
    }
