       if (check == 1)
       {
            var queryResult = context.SubjectContext
                .Where(x => x.CreatedBy == CreatedBy)
                .Select(x => new { x.Id, x.Name });
    
            if (queryResult.Any())
            {
                return jsonRetrunMsg = new JsonReturn { Status = "success", Message = queryResult };
            }
            else
            {
                return jsonErrorMsg = new JsonError { Status = "error", Message = "Check User Id" };
            }
    
        } else if (check == 0)
        {
            var queryResult = context.SubjectContext
                .Where(x => x.CreatedBy == CreatedBy)
                .Select(x => new { x.Id, x.Name, x.Skillset });
    
            if (queryResult.Any())
            {
                return jsonRetrunMsg = new JsonReturn { Status = "success", Message = queryResult };
            }
            else
            {
                return jsonErrorMsg = new JsonError { Status = "error", Message = "Check User Id" };
            }
        }
