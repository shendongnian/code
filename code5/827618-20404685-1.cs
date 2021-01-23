        PeopleController people = new PeopleController();
        // mismatched person Id returns BadRequest
        Person person = new Person();
        person.Id = 11;
        person.Name = "John updated";
        IHttpActionResult result = people.PutPerson(10, person).Result;
        Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        // ---------------------------------------------------
        // non-existing person
        Person person = new Person();
        person.Id = 1000;
        person.Name = "John updated";
        IHttpActionResult result = people.PutPerson(1000, person).Result;
        Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        // --------------------------------------------------------
        //successful update of person information and its verification
        Person person = new Person();
        person.Id = 10;
        person.Name = "John updated";
        IHttpActionResult result = people.PutPerson(10, person).Result;
        StatusCodeResult statusCodeResult = result as StatusCodeResult;
        Assert.IsNotNull(statusCodeResult);
        Assert.AreEqual<HttpStatusCode>(HttpStatusCode.NoContent, statusCodeResult.StatusCode);
        //retrieve the person to see if the update happened successfully
        IHttpActionResult getPersonResult = people.GetPerson(10).Result;
        OkNegotiatedContentResult<Person> negotiatedResult = getPersonResult as OkNegotiatedContentResult<Person>;
        Assert.IsNotNull(negotiatedResult);
        Assert.AreEqual<string>(person.Name, negotiatedResult.Content.Name);
