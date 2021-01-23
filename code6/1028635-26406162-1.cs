    public ActionResult Index()
    {
    
        var nationalities = new List<Nationality>
        {
            new Nationality{Id = 0, Name = "CHOOSE NATIONALITY..."},
            new Nationality{Id = 1, Name = "POLAND"},
            new Nationality{Id = 2, Name = "USA"},
            new Nationality{Id = 3, Name = "CANADA"}
        };
    
    
        var nationalities = new SelectList(nationalities, "Id", "Name");
    
    
        var persons = new List<PersonViewModel>
        {
            new PersonViewModel{Id = 1, LastName = "KOWALSKI", NationalityId = 1 , Nationalities = nationalities},
            new PersonViewModel{Id = 1, LastName = "SMITH", NationalityId = 2, Nationalities = nationalities},
            new PersonViewModel{Id = 1, LastName = "SCHERBATSKY", NationalityId = 3, Nationalities = nationalities}
        };    
        return View(persons);
    }
