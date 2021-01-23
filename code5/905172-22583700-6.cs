        public void WCFOperation()
        {
            try
            {
               ...
            }           
            catch (Exception ex)
            {
                Helpers.publishError(ex);
                throw Helpers.ConvertToSoapFault(ex);
            }
        }
