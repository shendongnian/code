    using System.IO;
    using (var reader = new StreamReader(fileName))
    {
       string line;
       while ((line = reader.ReadLine()) != null)
       {
          // Do stuff with your line here, it will be called for each 
          // line of text in your file.
       }
    }
