    public decimal CalculateInstalment(decimal amount, int months)
    {
        var result = 0.0;
        this.ExecutAction(() => { result = Math.Round((amount / months), 2); });
    }
    
   
    protected bool ExecutAction(Action action)
    {
        try
        {
            action();
            return true;
        }
        catch (NullReferenceException e) { _MessageService.ShowErrorMessage(e); return false; ; }
        catch (System.Data.SqlTypes.SqlTypeException e) { _MessageService.ShowErrorMessage(e); return false; }
        catch (System.Data.SqlClient.SqlException e) { _MessageService.ShowErrorMessage(e); return false; }
        catch (System.Exception e) { _MessageService.ShowErrorMessage(e); return false; };
    }
