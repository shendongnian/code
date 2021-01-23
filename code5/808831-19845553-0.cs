    public class vwcountry
    {
    public country country { get; set; }
    public IList<state> states { get; set; }
    }
    
    public class state
    {
    public state state { get; set; }
    public IList<city> cities { get; set; }
    }
