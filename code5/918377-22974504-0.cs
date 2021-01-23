    public class Invitation
    {
       public string EmailAddresss {get; set;}
       public int InvitationType {get; set; }
    }
    
    
    public ActionResult Register(MyCurrentModel dto, Invitation[] invitations)
    {
       //..
    }
