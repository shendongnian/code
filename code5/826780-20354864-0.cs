            class MyBaseEception : Exception
            {
            }
            class MyCustomException : MyBaseException {}
            try
            {
            }
            catch (Exception e)
            {
                if(e is MyBaseException)
                {
                    ....
                }
                else
                {
                    ...
                }
            }
