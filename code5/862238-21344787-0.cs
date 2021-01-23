    public class MyClass
    {
        string myClassVar; // this one is usable throughout the class
        void MyMethod()
        {
            string myMethodVar; // This one is visible inside this method
            string path = Application.StartupPath + "\\checkfiles.lst";
            // Open the file to read from.
            foreach (string readText in File.ReadLines(path))
            {
                var elements = readText.Split('|');
                string Elementsfile = elements[0];    // these ones are visible inside the for loop
                string HashString = elements[1];
                string ByteSize = elements[2];
                Console.WriteLine(Elementsfile + HashString + ByteSize);
            }
         }
    }
