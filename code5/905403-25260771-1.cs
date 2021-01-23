    public class MySecondTypeDto
    {
    public string Surname { get;set; }
    public string Name{ get;set; }
    public string FullName  {get; set;}
    var NonReturningPocoDto = new MyFirstTypeDto();
    NonReturningPocoDto.Name = "Robbie";
    NonReturningPocoDto.Surname = "Williams";
     var ReturningPocoDto = new MySecondTypeDto();
    ReturningPocoDto.Name = NonReturningPocoDto.Name;
    ReturningPocoDto.Surname = NonReturningPocoDto.Surname;
    ReturningPocoDto.FullName  = NonReturningPocoDto.FullName;
