    public static List<string> GetPeopleFromSession(){
        var people = HttpContext.Current.Session["mySession"] as List<string>;
        //Create new, if null
        if(people == null) 
            people = new List<string>();
        return people;
    }
