    using System.Collections;
    object queryResult;
            if (check == 1)
            {
                queryResult = context.SubjectContext
                    .Where(x => x.CreatedBy == CreatedBy)
                    .Select(x => new { x.Id, x.Name });
    
            } else if (check == 0)
            {
                queryResult = context.SubjectContext
                    .Where(x => x.CreatedBy == CreatedBy)
                    .Select(x => new { x.Id, x.Name, x.Skillset });
            }
    
            if ((queryResult != null) && ((queryResult as ICollection).Count > 0))
            {
                return jsonRetrunMsg = new JsonReturn { Status = "success", Message = queryResult };
            }
            else
            {
                return jsonErrorMsg = new JsonError { Status = "error", Message = "Check User Id" };
            }
