    catch (SqlException ex)
    {
        bResult = false;                   
        if (ex.Errors[0].Class == -10)
        {
            CommonTools.vAddToLog("bInsertNewUser", "ManageUsers", ex.Message);
            if ((savePoint != null))
                savePoint.Rollback();
        }
    } 
