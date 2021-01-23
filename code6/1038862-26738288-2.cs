    //data class
    class Person
    {
      public string Name {get;set;}
      public List<string> SoldItems {get;set;}
    }
    
    //fill data
    List<Person> Persons = new List<Person>();
    int itemColumnCount = 3;
    while (dr.Read())
    {
      Person person = new Person();
      person.SoldItems = new List<string>();
      //Get person name
      person.Name = dr.GetString(dr.GetOrdinal("personNameColumn"));
      //Get sold items
      for(int i = 1; i <= itemColumnCount; i++)
      {
        //lets say you have columns: ItemSoldColumn1, ItemSoldColumn2, ItemSoldColumn3 for example
        string columnName = "ItemSoldColumn" + i;
        //check if column value is not null
        if(!dr.IsDBNull(dr.GetOrdinal(columnName)))
        {
          string soldItem = dr.GetString(dr.GetOrdinal(columnName));
          //add to persons sold items list
          person.SoldItems.Add(soldItem);
        }
      }
    }
