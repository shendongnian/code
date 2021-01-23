    public JsonResult Person(string term)
    {
        var persons = FindPersons(term,"bk@example.com","bk").ToArray();
        
        return Json(persons.Select(p => new { label = p.FirstName + " " + p.LastName, value = p.Email }), JsonRequestBehavior.AllowGet);
    }
