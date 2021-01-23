    public class CustomAttribute1: Attribute
    {
        public CustomAttribute1([CallerMemberName] string propertyName = null, [CallerFilePath] string filePath = null)
        {
            //Returns "Name"            
            Console.WriteLine(propertyName);
            //Returns full path of the calling class
            Console.WriteLine(filePath);
        }
    }
