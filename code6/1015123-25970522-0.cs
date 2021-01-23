    public class PersonnelInfo(){
    public int PersonId {get; set;}
    public string LastName {get; set;}
    public string FirstName {get; set;}
    [Key, ForeignKey("Gender")]
    public int GenderId {get; set;}
    public virtual Gender Gender { get; set; }
    }
