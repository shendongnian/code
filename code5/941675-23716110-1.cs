           void EndAsyncOperation1(IAsyncResult ar)
        {
            try
            {
                task1.EndInvoke(ar);
                success1 = true;
            }
            catch (Exception e1)
            {
                success1 = false;
                //log the exception (this will log error and also send out an error email)
                Elmah.ErrorSignal.FromCurrentContext().Raise(e1);
            }
            if (success1 == null)
            {
                success1 = true;
            }
        }
