    public partial class Terminal : XTimeEntity
    {
      public Terminal()
      {
        ControllerInterfacePointers = new List<ControllerInterfacePointer>();
        TerminalParameters = new List<TerminalParameter>();
      }
    
      public string Name { get; set; }
      public string Version { get; set; }
      public short Enabled { get; set; }
      [Required] //I think this line will trick EF into liking you.
      public virtual CanteenTerminal CanteenTerminal { get; set; }
      public short CanteenTerminalId { get; set; }
      public virtual ICollection<ControllerInterfacePointer> ControllerInterfacePointers { get; set; }
      public virtual ICollection<TerminalParameter> TerminalParameters { get; set; }
    };
