    //class to strongly type our results
    public class csvClass
    {
       public csvClass(string name; string mu)
       {
         this.Name = name; this.MobileUsage = mu;
       }
       public string Name { get; set; }
       public string MobileUsage { get; set; }
    }
    //just load your csv from wherever you need
    var csvData = from row in File.ReadLines(@"Path/to/file.csv")
                  // data is still in one line. Split by delimiter
                  let column = row.Split(';')
                  //strongly type result
                  select new csvClass
                  {
                      //Ingore column 2 and 4
                      //Take first column
                      Name = column[0],
                      //Take third column
                      MobileUsage = column[2]
                  };
	
