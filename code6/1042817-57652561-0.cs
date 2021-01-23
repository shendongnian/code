    using System;
    using System.Collections;
    namespace ConsoleEnum
    {   
       public class car : IComparable
       {      
          // Beginning of nested classes.
    
          // Nested class to do ascending sort on year property.
          private class sortYearAscendingHelper: IComparer
          {
             int IComparer.Compare(object a, object b)
             {
                car c1=(car)a;
                car c2=(car)b;
    
                if (c1.year > c2.year)
                   return 1;
    
                if (c1.year < c2.year)
                   return -1;
    
                else
                   return 0;
             }
          }
    
          // Nested class to do descending sort on year property.
          private class sortYearDescendingHelper: IComparer
          {
             int IComparer.Compare(object a, object b)
             {
                car c1=(car)a;
                car c2=(car)b;
    
                if (c1.year < c2.year)
                   return 1;
    
                if (c1.year > c2.year)
                   return -1;
    
                else
                   return 0;
             }
          }
    
          // Nested class to do descending sort on make property.
          private class sortMakeDescendingHelper: IComparer
          {
             int IComparer.Compare(object a, object b)
             {
                car c1=(car)a;
                car c2=(car)b;
                 return String.Compare(c2.make,c1.make);
             }
          }
    
          // End of nested classes.
    
          private int year;
          private string make;
            
          public car(string Make,int Year)
          {
             make=Make;
             year=Year;
          }
    
          public int Year
          {
             get  {return year;}
             set {year=value;}
          }
    
          public string Make
          {
             get {return make;}
             set {make=value;}
          }
    
          // Implement IComparable CompareTo to provide default sort order.
          int IComparable.CompareTo(object obj)
          {
             car c=(car)obj;
             return String.Compare(this.make,c.make);
          }
    
          // Method to return IComparer object for sort helper.
          public static IComparer sortYearAscending()
          {      
             return (IComparer) new sortYearAscendingHelper();
          }
    
          // Method to return IComparer object for sort helper.
          public static IComparer sortYearDescending()
          {      
             return (IComparer) new sortYearDescendingHelper();
          }
    
          // Method to return IComparer object for sort helper.
          public static IComparer sortMakeDescending()
          {      
            return (IComparer) new sortMakeDescendingHelper();
          }
    
       }
    }
