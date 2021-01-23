    return base.SendAsync(request, cancellationToken).ContinueWith(
                            task =>
                            {
                               
                                var headers = task.Result.ToString();
                                var body = task.Result.Content.ReadAsStringAsync().Result;
    
                                // RETURN THE ORIGINAL RESULT
                                var response = task.Result;
                                return response;
                            }
                );
      
