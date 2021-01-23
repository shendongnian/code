    var data = new List<Member>
    {
        new Member { FirstName = "A", LastName = null },
        new Member { FirstName = "B", LastName = null },
        new Member { FirstName = "A", LastName = "NotNull" },
        new Member { FirstName = "B", LastName = "NotNull" }
    };
    
    var result = data.OrderBy(x => x.LastName).ThenBy(x => x.FirstName);
