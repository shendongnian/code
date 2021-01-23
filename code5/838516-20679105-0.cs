    public ActionResults GetSomeData(MyCustomViewModel  model){
          // add the first element
          var person = Person.Add(MyCustomViewModel.Person);
          // update the second object in model, with related / needed ID
          MyCustomViewMOdel.PersonContent.PersonId = person.id;
          // add in related content
          var AddedContent = PersonContent.Add(myCustomViewModel.PersonContent);
    }
