    public class SecondClass
    {
        public Holder Holder { get; set; }
      
        public SecondClass(){}
        public void SecondClassMethod()
        {
            if (Holder!=null)
            {
                Holder.Name = "John";
                Console.WriteLine(Holder.Name + " from SecondClass");
            } 
        }
    }
