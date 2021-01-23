    // initialise entityTask here if needed outside of the scope of the try/catch
    try
    {
        cAuditTaskEntity entityTask = (cAuditTaskEntity)tvTasks.SelectedItem;
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
