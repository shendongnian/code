    var model =  new Student //deleted parenthesis
    {
        FirstName = "John",
        LastName = "Doe",
        Dob = DateTime.Now,    
        State = new List<State>//deleted parenthesis
            {
    //          new State({ID="1" , Name = "test1"}); don't wrap params in parenthesis
                new State{ID="1" , Name = "test1"},
                new State{ID="2" , Name = "test2"},
                new State{ID="3" , Name = "test3"}
            }    
    }
