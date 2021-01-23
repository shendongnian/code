            class MyBaseEception : Exception
            {
            }
            class MyCustomException : MyBaseException {}
            try
            {
            }
            catch (MyBaseException customException) {....}
            catch (Exception e)
            {
            }
