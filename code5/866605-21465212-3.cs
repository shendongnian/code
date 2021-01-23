    catch (Exception e)
    {
        try
        {
            tran.Rollback();
        }
        catch (Exception exRollback)
        {
            Console.WriteLine(exRollback.Message);
        }
        throw;
    }
