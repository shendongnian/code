    sealed class Param
    {
        public string Name
        {
            get;
            private set;
        }
        public object Value
        {
            get;
            private set;
        }
        public Param(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
    public T Execute<T>(Func<T> body, params Param[] parameters)
    {
        //wrap everything in common try/catch
        try
        {
            return body();
        }
        catch (SoapException)
        {
            //rethrow any pre-generated SOAP faults
            throw;
        }
        catch (Exception ex)
        {
            Logger.AddTextToLog(Logger.LogLevel.Error, "An error occured");
            foreach (var parameter in parameters)
            {
                Logger.AddTextToLog(
                                    Logger.LogLevel.Error,
                                    string.Format(
                                                  "{0} : {1}",
                                                  parameter.Name,
                                                  parameter.Value ?? "null"));
            }
            var innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : "";
            throw GenerateSoapException(
                                        ex.Message,
                                        innerExceptionMessage,
                                        SoapException.ServerFaultCode);
        }
    }
