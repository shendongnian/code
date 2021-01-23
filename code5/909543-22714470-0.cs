    public class FormatDatesModule : IHttpModule
    {
        private static readonly Regex dateFilter = new Regex(@"^(?<d>\d{2})\/(?<m>\d{2})\/(?<y>\d{4})$", RegexOptions.Compiled);
        
        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender,e) => {
                HttpRequest request = ((HttpApplication)sender).Request;
                
                if (request.QueryString.Count > 0)
                {
                    this.FormatDatesInCollection(request.QueryString);
                }
                
                if (request.HttpMethod == "POST" && request.Form.Count > 0)
                {
                    this.FormatDatesInCollection(request.Form);
                }
            };
        }
        
        private static void FormatDatesInCollection(NameValueCollection parameters)
        {
            // Bypass readonly
            PropertyInfo isReadOnly = parameters.GetType().GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
            isReadOnly.SetValue(parameters, false, null);
            
            for (var i = 0; i < parameters.Count; i++)
            {
                Match dateMatch = dateFilter.Match(parameters[i]);
                if (dateMatch.Success)
                {
                    parameters[i] = String.Join("/", dateMatch.Groups["m"].Value, dateMatch.Groups["d"].Value, dateMatch.Groups["y"].Value);
                }
            }
            
            isReadOnly.SetValue(parameters, true, null);
        }
        
        public void Dispose()
        {
        }
    }
