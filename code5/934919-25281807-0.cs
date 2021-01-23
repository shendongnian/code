    public class GPFToolAttribute : Attribute
    {
            /// <summary></summary>
    protected string _description;
    /// <summary></summary>
    protected string _name;
        // Constructors
        public GPFToolAttribute(){
        
        }
    public string Description
    {
      get { return _description; }
    }
            /// <summary>
    ///
    /// </summary>
    public string Name
    {
      get { return _name; }
    }
            /// <summary>
    ///
    /// </summary>
    /// <param name="name"></param>
    public GPFToolAttribute(string name) :
      this(name, "")
    {
    }
            /// <summary>
    ///
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    public GPFToolAttribute(string name, string description)
    {
      _name = name;
      _description = description;
    }
    }
