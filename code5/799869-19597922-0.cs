    public IQueryable <MyGetResult> Get()
    
    {
    
        var query =
            from MY_ENTITY_1 in my_entity_1
            from MY_ENTITY_2 in my_entity_2
            from MY_ENTITY_3 in my_entity_3
    
            where
                 MY_ENITITY_1.something == MY_ENTITY_2.something
    
            select new MyGetResult
                {
                    Result1 = MY_ENTITY_1.FOO1,
                    Result2 = MY_ENTITY_2.FOO2,
                    Result3 = MY_ENTITY_3.FOO3
                };
        return query;
    }
    
    public class MyGetResult
    {
        public Foo Result1 {get;set;}
        public Foo Result2 {get;set;}
        public Foo Result3 {get;set;}
    }
