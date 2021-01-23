        public void WCFOperation()
        {
            try
            {
               ...
            }
            catch (MyException ex)
            {
                Helpers.publishError(ex);
                throw Helpers.ConvertToSoapFault(ex);
            }
            catch (Exception ex)
            {
                Helpers.publishError(ex);
                throw Helpers.ConvertToSoapFault(ex);
            }
        }
