    public abstract class Class2
    {
        protected DateTime Added { get; set; }
        protected int ID { get; set; }
    }
    public class Class1 : Class2
    {
        public string ImageFilename { get; set; }
        public string LinkText { get; set; }
        public Class1()
        {
            //You can set the variables from inside Class 1.
            base.Added = DateTime.Now();
            base.ID = 1;
        }
    }
