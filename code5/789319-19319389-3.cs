    catch (Exception ex)            
    {                
        if (ex is FormatException || ex is IndexOutOfRangeException )
        {
            Console.WriteLine(ex.Message);
        }
        else
        {
            throw;
        }
    }
    finally
    {
        streamwriter.Close();
        filestream.Close();
    }
