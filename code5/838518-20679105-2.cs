    public ActionResult GetSomeData(MyCustomViewModel  model){
          // add the first element
          var person = Person.Add(model.Person);
          // update the second object in model, with related / needed ID
          model.PersonContent.PersonId = person.id;
          // add in related content
          var AddedContent = PersonContent.Add(model.PersonContent);
    }
