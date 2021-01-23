    enum Comparison {
       LessThan=-1, Equal=0, GreaterThan=1};
    
    public class ValueComparison
    {
       public static void Main()
       {
          int mainValue = 16325;
          int zeroValue = 0;
          int negativeValue = -1934;
          int positiveValue = 903624;
          int sameValue = 16325;
    
          Console.WriteLine("Comparing {0} and {1}: {2} ({3}).",  
                            mainValue, zeroValue, 
                            mainValue.CompareTo(zeroValue), 
                            (Comparison) mainValue.CompareTo(zeroValue));
        }
    }
