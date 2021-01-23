         protected void radScriptManager_AsyncPostBackError(object sender, 
                                             System.Web.UI.AsyncPostBackErrorEventArgs e)
        {
            //log the exception using ELMAH or any other logging mechanism
            Exception ex = Server.GetLastError() ;
            if (ex != null)
            {
                Exception bex = ex.GetBaseException();
                if (bex != null)
                {
                    Elmah.ErrorSignal.FromCurrentContext().Raise(bex);
                }
            }
            Server.ClearError();
        }
