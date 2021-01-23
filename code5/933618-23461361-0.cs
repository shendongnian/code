    //This is sample parent object
    
    public class Container : Panel
    {
      // In your situation this list is your controls
      public List<NumBox> Elements { get; set; }
    
      public Container()
      {
      }
      public Container( List<NumBox> numericBoxList )
      {
        this.Elements.AddRange( numericBoxList ) ;
      }
    
      public void Add ( NumBox numericBoxInstance )
      {
        // we check that elements has our numbox instance or not..
        // if our instance is not in the elements then find method returns null
        if (this.Elements.Find( numericBoxInstance ) == null)
        {
          this.Elements.Add ( numericBoxInstance )
        }
    
        public void DeleteElement ( NumBox numboxInstance )
        {
          this.Elements.Remove (numboxInstance );
        }
    
        public void DeleteAllElements ()
        {
          this.Elements = null;
          // The IENumerable objects such as Lists can be easily set the object to the 
          // "initialization moment" - something like just create a new and empty object - 
          // with assigning to "null"..CSharp compiler as clever as understand that you want clear all
        }
    
        public void UpdateElement (int indexNo, NumBox updatedNumBox)
        {
          this.Elements[indexNo] = updatedNumBox;
        }
    
    // And The Sample Child object
    
    public class NumBox : TextBox
    {
    
       public NumBox()
       {
       }
    
       public NumBox ( int value )
       {
         this.Text = value.ToString();
       }
    
       //overloads for other numeric options such as short, long, decimal, float etc.
    
        public void Reset()
        {
          this.Text = null;
        }
       // Some Other Useful Methods that you need in the project
    } 
