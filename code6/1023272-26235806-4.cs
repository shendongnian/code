    public class Person
    {
      public int ID { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public String NumbersString { get; set; }
      
      private int[] _numbers;
      public int[] Numbers
        {
             get
                 {
                    return _numbers;
                 }
             set
                {
                  _numbers = value;
                  NumbersString = FormatIntoString(_numbers);
                }
      
         }
      public Person()
      {
      numbers = new int[6];
      }
     
     // The write the method that puts the array into a readable form
     
     private string FormatIntoString(int[] array)
       {
         string result = "";
         foreach(var x in array)
          {
            result += x.ToString() + ",";
          }
         return result;
       }
    
