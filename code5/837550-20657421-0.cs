    cAuditTaskEntity = null;
    try
    {
        cAuditTaskEntity entityTask = _tasks.SelectedItem as cAuditTaskEntity;
        ... your logic here ...
    }
    catch(InvalidCastException invEx)
    {
        // do nothing here, another type of task has been selected, cErrorTaskEntity for example
    }
    catch(Exception ex)
    {
        throw new Exception("something else went wrong!", ex);
    }
