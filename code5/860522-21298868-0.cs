    public class MyClass
    {
        int Id;
        int StudentId;
        //etc
    }
    var resultsWithId = query.Select((q, i) => new MyClass { 
                                                     Id = i, 
                                                     StudentId = q.StudentId 
                                                     //etc
                                                   });
