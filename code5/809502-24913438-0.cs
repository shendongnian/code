    await Task.Run(() => {
               
                    try
                    {
                        throw new Exception("Bang!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);   
                    }
 
            });
