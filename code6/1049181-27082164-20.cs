        try
        {
            throw new FileNotFoundException();
        }
        catch (FileNotFoundException e)
        {
            if (!e.FileName.Contains("Hamster"))
            {
                throw;
            }
            // Handle
        }
        catch (Exception e)
        {
            // Unreachable code
        }
