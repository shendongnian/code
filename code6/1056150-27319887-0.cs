    // Event handler
    private void button1_Click(object sender, EventArgs args)
    {
          LibraryClass.DoStuff(...); // Pass whatever parameters might be needed
    }
    
    // In a separate project
    public class LibraryClass
    {
          public static void DoStuff(...)
          {
                // Move the code from your event handler here
          }
    }
    
    // In a console app
    class Program
    {
          static void Main(string [] args)
          {
                LibraryClass.DoStuff(...);  // pass whatever parameters are needed
          }
    }
