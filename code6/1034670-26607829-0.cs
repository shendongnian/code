    public class Budget
    {
    public int Id { get; set; }
    //
    public int N1 { get; set; }
    public Nullable<int> N2 { get; set; }
    public Nullable<int> N3 { get; set; }
    public Nullable<int> N4 { get; set; }
    //
    public float Amount { get; set; }
    /// <summary>
    /// Method analyzes if current object is a parent of <paramref name="other"/>
    /// if you override GetHashCode or provide a nifty bit array representation 
    /// you can infer parent-child relationships with really fast bit shifting 
    /// </summary>
    /// <param name="other">budget to compare with</param>    
    public bool IsParentOf (Budget other)
    {
      // ommitted for too-time-consuming and 'your work obviously' 
      // or 'not-the-purpose-of-this-site'reasons
      return true;
    }
    }
