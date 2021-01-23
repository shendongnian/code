       QueryResponse<Result> response = result.ConvertTo<QueryResponse<Result>>();
        response.Results = new List<Result>();
        
        foreach (Person p in result.Results)
         {
            
           response.Results.Add(new Result{ Id = p.EmployeeId, Label = (p.FirstName + " " + p.LastName) });
         }
       return response
