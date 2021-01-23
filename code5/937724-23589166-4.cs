    public class PathHelper
    {
         private static int MaxPathLength {get; set;}
         static PathHelper()
         {
              // reflection
              FieldInfo maxPathField = typeof(Path).GetField("MaxPath", 
                  BindingFlags.Static | 
                  BindingFlags.GetField | 
                  BindingFlags.NonPublic );
              // invoke the field gettor, which returns 260
              MaxPathLength = (int) maxPathField.GetValue(null);
         }
         public static bool IsPathWithinLimits (string fullPathAndFilename)
         {          
              return fullPathAndFilename.Length<=MaxPathLength;
         }
    }
