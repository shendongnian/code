    public static List<string> GetPeopleFromSession(){
        people = Session["mySession"] as List<string>;
        //Create new, if null
        if(people == null) 
            people = new List&lt;string&gt;();
        return people;
    }
