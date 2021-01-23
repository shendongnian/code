    int tryCounter = 0;
    while (true)
    {
        try
        {
            tryCounter++;
            //your code here 
            break;
        }
        catch (IOException) //please check if your code does throw an IOException
        {                   //i am just guessing 
            if (tryCounter >= 10)
            {
                throw;
            }
    
            Thread.Sleep(10);
        }
    }
