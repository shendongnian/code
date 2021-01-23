    var model =  new Student //deleted parenthesis
    {
        FirstName = "John",
        LastName = "Doe",
        Dob = DateTime.Now,
    
        State = new list<State>//deleted parenthesis
            {
    //          new state({ID="1" , Name = "test1"}); don't wrap params in parenthesis
                new state{ID="1" , Name = "test1"},
                new state{ID="2" , Name = "test2"},
                new state{ID="3" , Name = "test3"}
            };
    
    }
