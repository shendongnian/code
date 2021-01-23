    public ProductVersions[]verArray = {
          new ProductVersions() { Version_Id = 1, Major = 3, Minor = 0, Build = 1 },
          new ProductVersions() { Version_Id = 2, Major = 4, Minor = 10, Build = 5 },
          new ProductVersions() { Version_Id = 3, Major = 6, Minor = 2, Build = 1 },
          new ProductVersions() { Version_Id = 4, Major = 7, Minor = 5, Build = 1 },
          new ProductVersions() { Version_Id = 5, Major = 10, Minor = 7, Build = 1 },
          new ProductVersions() { Version_Id = 6, Major = 11, Minor = 10, Build = 10 },
      };
    
    void Main()
    {
      string test = "10.10.20";
      Console.WriteLine(test + " gives "+GetVersion(test));
    
      test = "7.0.0";
      Console.WriteLine(test + " gives "+GetVersion(test));
      
      test = "7.5.1";
      Console.WriteLine(test + " gives "+GetVersion(test));
    }
    
    private int GetVersion(string versionNumber)
       {
         string [] input = versionNumber.Split(".".ToCharArray());
         
         int major = int.Parse(input[0]);
         int minor = int.Parse(input[1]);
         int build = int.Parse(input[2]);
    
         // assume verArray is already ordered (this would need to be sorted otherwise.
         int result = verArray.Where(v => (v.Major < major) ||
                                          (v.Major == major && v.Minor < minor) ||
                                          (v.Major == major && v.Minor == minor && v.Build <= build)).Last().Version_Id;
    
         return result;
        }
    
        public class ProductVersions
        {
            public int Version_Id { get; set; }
            public int Major { get; set; }
            public int Minor { get; set; }
            public int Build { get; set; }
        }
        
