    public class MyViewModel()
    {
        public T PropertyOne { get; set; }
        public T PropertyTwo { get; set; }
        public MyOtherViewModel PropertyThree { get; set; }
    }
    public class MyOtherViewModel()
    {
        public T PropertyOneCheck { get; set; }
        public T PropertyTwoCheck { get; set; }
    }
