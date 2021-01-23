    //Your main method example
    static class Program 
    {
       internal static bool AreYouOKAY = false;
       // or public static bool as your needs
      
       static void Main ()
       { 
           ........
       }
    
    /// And in your form
    
    Program.AreYouOKAY = true;
    
    // After your form closed.. from another form just call as above
    
    if(Program.AreYouOKAY)
    {
      MessageBox.Show (" Yeah! I'm Ok!");
    }
