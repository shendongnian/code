    class Program
    {
        static void Main(string[] args)
        {
           Recursion("000012345",0);
        }
        static void Recursion(string value,int c)
        {
            String MobileNo = value;
            int count=c;
          
            if (MobileNo.StartsWith("0") && count<3)
            {
                count++;
                Recursion(MobileNo.Remove(0, 1),count);
            }
         }
     }
