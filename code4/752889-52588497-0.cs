    public static async Task NoSwallow<TException>(this Task task) where TException : Exception {
        try {
            await task;
        } catch (TException) {
            var unexpectedEx = task.Exception
                                   .Flatten()
                                   .InnerExceptions
                                   .FirstOrDefault(ex => !(ex is TException));
            if (unexpectedEx != null) {
                throw new NotImplementedException(null, unexpectedEx);
            } else {
                throw task.Exception;
            }
        }
    }
