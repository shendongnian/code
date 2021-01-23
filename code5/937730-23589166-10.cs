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
             //the NUL terminator is part of MAX_PATH https://msdn.microsoft.com/en-us/library/aa365247.aspx#maxpath
                   MaxPathLength--; //So decrease by 1
         }
         public static bool IsPathWithinLimits (string fullPathAndFilename)
         {          
              return fullPathAndFilename.Length<=MaxPathLength;
         }
    }
