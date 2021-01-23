    public partial class PartialClass    
    {        
        public void showa()
        {
            showaImpl();
        }
        partial void showaImpl(); 
    }
    public partial class PartialClass
    {
        string b = "b";
        partial void showaImpl()
        {
            Console.Write(b);
        }
    }
