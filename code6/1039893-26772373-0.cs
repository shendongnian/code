    public class People{
        public Person Person{set;get;}
    }
    public JsonResult GetAllPeople()
    {
        List<People> PeopleList= new List<People>();
        foreach(string data in something){
        //Some code to get data
        Person p = new Person(); 
        p.FirstName = data.FirstName ;
        p.LastName  = data.LastName 
        p.Age = data.Age;
        PeopleList.Add(new People(){Person = p});
        }        
        return Json(new { People = PeopleList },JsonRequestBehavior.AllowGet);
    }
