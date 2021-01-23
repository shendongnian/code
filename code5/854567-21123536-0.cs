    public class myBLL
    {
        public static addByID(int ID)
        {
            //do some stuff
            LogString("You have added: {0}", ID);
        }
    
        public static removeByID(int ID)
        {
            //do some other stuff
            LogString("You have removed: {0}", ID);
        }
    
        public static LogString(string message, int ID)
        {
            string myString = "";
    
            if(ID == 1)
                myString = "string 1";
            else
                myString = "string 2";
    
            Console.WriteLine(string.Format(message, myString);
         }
    }
