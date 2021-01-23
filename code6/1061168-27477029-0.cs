        catch (Exception ex)
        {
            Response.Write(ex); //<------ check this out, there must be an exception bubbling up
            sqlConn.Close();
            sqlConn.Dispose();
        }
