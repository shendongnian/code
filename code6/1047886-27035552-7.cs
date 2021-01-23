	public class Order
	{
        //todo: if Name, TID or CommandName changes you'd have to initialize a new Command objects with the new values
	    [XmlAttribute("Name")]
	    public string Name {get;set;}
	    [XmlAttribute("TID")]
	    public string TID {get;set;}
	    [XmlAttribute("CommandName")]
	    public string CommandName {get;set;}
	    private Command command;
	    [XmlIgnore]
	    public Command Command
	    {
		  get
	   	  {
		    return command ?? (command = new Command(TID, Name, CommandName));
	      }
        }
	    public Order()
	    {
	    }
	}
