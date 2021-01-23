    public class MyException():Exception
    { 
        public long Id { get; set; }
        public MyException(long id): base("Your text goes here")
        {
            this.Id = id;
            // and do some logging
        }
    }
