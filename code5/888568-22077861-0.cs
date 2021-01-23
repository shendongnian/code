    string[] csvLines = File.ReadAllLines(@"c:\employees.csv")
    
    List<Task> tasks = new List<Tasks>();
    
    foreach(var line in csvLines )
    {//spawn tasks to parse, validate , save
       var task = Task<ValidationResult>.Factory.StartNew(()=>
         {//async task start
               
             var validationResult = Validate(line);
             if(validationResult.IsValid)
             {
                Save(validationResult.Employee);
             }     
    
             return validationResult; 
    
         });//async task end
         tasks.Add(task);
    }
    
    //wait for results
    var allResults = new List<ValidationResult>();    
    foreach(var t in tasks)
    {
     allResults.Add(t.Result);
    }
