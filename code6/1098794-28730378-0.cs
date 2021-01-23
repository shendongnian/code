    public class Parent
    {
        public string Field1 { get; set; }
        public Level1 Level1 { get; set; }
        public static Parent GetInstance()
        {
            return new Parent() { Field1 = "1", Level1 = new Level1 { Field2 = "2", Level2 = new Level2() { Field3 = "3"}}};
        }
        private Parent()  {              }
    }
    public class Level1
    {
        public string Field2 { get; set; }
        public Level2 Level2 { get; set; }
    }
    public class Level2
    {
        public string Field3 { get; set; }
    }
