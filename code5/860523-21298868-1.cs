    public class MyClass
    {
        int Id;
        int StudentId;
        //etc
    }
    var resultsWithId = query.Select((q, i) => new MyClass { 
                                                     Id = i + 1, //one based index 
                                                     StudentId = q.StudentId 
                                                     //etc
                                                   });
