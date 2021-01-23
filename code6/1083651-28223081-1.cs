      string sourceTemplate =
          @"using System; 
            using System.Windows.Forms; 
            namespace Sample1 { 
               public static class Bar { 
                  public static void Execute(TextBox textBox1) {
                     @Placeholder
                  }
               }
            }";
