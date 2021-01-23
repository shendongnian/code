    class Service : IService
    {
        public ResponseObj GetObj()
        {
            if (success)
            {
                return new ResponseObj();
            }
            else
            {
                throw new FaultException<ErrorResponseObj>(new ErrorResponseObj() 
                {
                    ErrorMessage = "Something Happened"
                })
            }
        }
    } 
