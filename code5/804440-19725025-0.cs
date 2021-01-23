        [System.Diagnostics.DebuggerNonUserCode()]
        private void FunctionThatCatchesThrownException()
        {
            try
            {
                throw new ArgumentOutOfRangeException();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                //...
            }
        }
