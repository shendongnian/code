    public T Execute<T, TU>(Func<T> body, TU parameterClass) where TU : class
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
                var serializedObject = ParameterUtil.GetPropertyNamesAndValues(parameterClass);                
                Logger.AddTextToLog(Logger.LogLevel.Error, string.Format("An error occured when calling braArkiv Web Services. Web service method arguments: {0}", serializedObject), ex);
                var innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : "";
                throw GenerateSoapException(
                                            ex.Message,
                                            innerExceptionMessage,
                                            SoapException.ServerFaultCode);
            }
    }
     public static class ParameterUtil
        {       
            public static string GetPropertyNamesAndValues<T>(T o) where T : class
            {
                using (var stringWriter = new StringWriter())
                {
                    var xmlSerializer = new XmlSerializer(o.GetType());
                    xmlSerializer.Serialize(stringWriter, o);
                    stringWriter.Close();
                    return stringWriter.ToString();
                }            
            }        
        }
