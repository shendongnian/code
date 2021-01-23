    //allow the db to do the work 
    public IEnumerable<Person> GetPersons(){
      using(var db = new MyEntities()){
      var stuff = db.Database.SqlQuery<Person>(querystring, parameters); 
      return stuff.ToList();
    }}
