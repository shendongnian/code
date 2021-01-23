    public void HandleExceptions(Action action)
    {
        try
        {
            action();
        }
        catch (ExceptionA exa)
        {
        }
        catch (ExceptionB exb)
        {
        }
        finally
        {
        }
    }
