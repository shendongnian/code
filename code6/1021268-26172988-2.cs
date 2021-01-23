    var json = JsonConvert.SerializeObject(new ResponseError 
                                               { 
                                                  ErrorCode = 500, 
                                                  ErrorMessage = "oh no !" 
                                               });
    context.Response.Write(json);
