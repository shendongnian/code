    protected T TryExecutAction<T>(Func<T> func, out bool success)
    {
        try
        {
            T temp = func();
            success = true;
            return temp;
        }
        catch (NullReferenceException e) { _MessageService.ShowErrorMessage(e);  }
        catch (System.Data.SqlTypes.SqlTypeException e) { _MessageService.ShowErrorMessage(e); }
        catch (System.Data.SqlClient.SqlException e) { _MessageService.ShowErrorMessage(e);  }
        catch (System.Exception e) { _MessageService.ShowErrorMessage(e); };
    
        success = false;
        return default(T);
    }
