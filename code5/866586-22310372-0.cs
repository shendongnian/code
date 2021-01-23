    //model
    public class Person
    {
     public int Id {get;set;}
     public string FirstName {get;set;}
     public string LastName {get;set;}
    }
    //controller
    public class HomeController : Controller
    {
     public ActionResult Index(Person person)
     {
      if("POST".Equals(Request.HttpMethod))
      {
         //for example do some validation and redirect
      }
     return View(person);
     }
    }
    //view
    @model Application.Models.Person //only as example use own
    @using(Html.BeginForm("Index","Home", FormMethod.POST))
    {
    @Html.HiddenFor(x=> x.Id)
      <div>
    @Html.LabelFor(x=> x.FirstName)
    @Html.TextBoxFor(x=> x.FirstName)
    </div>
    <div>
    @Html.LabelFor(x=> x.LastName)
    @Html.TextBoxFor(x=> x.LastName)
    </div>
    <input type="submit" value="Do a post request"/>
    }
