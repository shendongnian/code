    public class MyFirstTypeDto
    {
    public string Surname { get;set; }
    public string Name{ get;set; }
    public string FullName {get { Name + " " +Surname }}
