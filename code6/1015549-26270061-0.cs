    public class PerformLogIn : ILogInService
        {
             public void LogIn(string code)
             {
                 ServiceReference1.WeatherSoapClient obj = new ServiceReference1.WeatherSoapClient(
                                            new BasicHttpBinding(),
                                            new EndpointAddress("http://wsf.cdyne.com/WeatherWS/Weather.asmx"));
                 obj.GetCityForecastByZIPAsync(code);
                 obj.GetCityForecastByZIPCompleted+=getResult;
             }
             void getResult(Object sender,GetCityForecastByZIPCompletedEventArgs e)
             {
                 string error = null;
                 
                 if (e.Error != null)
                     error = e.Error.Message;
                 else if (e.Cancelled)
                     error = "cancelled";
                 var result = e.Result; 
             }
       }
