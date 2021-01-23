    try
                        {
                            if (task.Result == null)
                            {
                                return new AjaxResponse();
                            }
    
                            if (task.Result is AjaxResponse)
                            {
                                return task.Result;
                            }
                            
                            return new AjaxResponse(task.Result);
                        }
