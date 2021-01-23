     using SharpDX.DirectWrite;
     using System.Collections.Generic;
     using System.Linq;
     namespace WebberCross.Helpers
     {
         public class FontHelper
         {
             public static IEnumerable<string> GetFontNames()
             {
                 var fonts = new List<string>();
                 // DirectWrite factory
                 var factory = new Factory();
                 // Get font collections
                 var fc = factory.GetSystemFontCollection(false);
                 for (int i = 0; i < fc.FontFamilyCount; i++)
                 {
                     // Get font family and add first name
                     var ff = fc.GetFontFamily(i);
                     var name = ff.FamilyNames.GetString(0);
                     fonts.Add(name);
                 }
                 // Always dispose DirectX objects
                 factory.Dispose();
                 return fonts.OrderBy(f => f);
             }
         }
     }
