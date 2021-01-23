    public class Person
    {
        public bool FirstNameIsActive { get; set; }
        public bool SecondNameIsActive { get; set; }
    }
    
    public List<Person> list = new List<Person>() { 
        new Person() { 
            FirstNameIsActive = true, 
            SecondNameIsActive = false 
        }, 
        new Person() { 
            FirstNameIsActive = false, 
            SecondNameIsActive = true 
        } 
    };
    
    private IQueryable<Person> Filter(PropertyInfo property, bool isActive)
    {
        IQueryable<Person> queryableData = list.AsQueryable<Person>();
        //create input parameter
    	ParameterExpression inputParam = Expression.Parameter(typeof(Person));
    	//left contition
        Expression left = Expression.Property(inputParam, property);
        //right condition
        Expression right = Expression.Constant(isActive, typeof(bool));
        //equals
        Expression e1 = Expression.Equal(left, right);
        //create call
        MethodCallExpression whereCallExpression = Expression.Call(
                                                                typeof(Queryable),
                                                                "Where",
                                                                new Type[] { queryableData.ElementType },
                                                                queryableData.Expression,
                                                                Expression.Lambda<Func<Person, bool>>(e1, new ParameterExpression[] { inputParam }));
        //execute and return
        return queryableData.Provider.CreateQuery<Person>(whereCallExpression);
    }
    
    private void test()
    {
    	Filter(typeof(Person).GetProperty("FirstNameIsActive"), true);
        Filter(typeof(Person).GetProperty("SecondNameIsActive"), true);
    }
