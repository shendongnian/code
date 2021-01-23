        return widthInches;      
    }
     public static void Main() 
     {
        // Declare a class instance "myBox":
        Box myBox = new Box(30.0f, 20.0f);
        // Declare an interface instance "myDimensions":
        IDimensions myDimensions = (IDimensions) myBox;
        // Print out the dimensions of the box:
        /* The following commented lines would produce   compilation 
         errors because they try to access an explicitly implemented
         interface member from a class instance:                   */
      //System.Console.WriteLine("Length: {0}", myBox.Length());
      //System.Console.WriteLine("Width: {0}", myBox.Width());
      /* Print out the dimensions of the box by calling the methods 
         from an instance of the interface:                         */
      System.Console.WriteLine("Length: {0}", myDimensions.Length());
      System.Console.WriteLine("Width: {0}", myDimensions.Width());
       }
    }
