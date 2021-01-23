    public void CallbackDelegate( string str ); 
     public T Execute<T>(Func<T> body, CallbackDelegate callback)
                {
                    //wrap everything in common try/catch
                    try
                    {  
                         //do stuff              
                        callback("results are...");
                    }
