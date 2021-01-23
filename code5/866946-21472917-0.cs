            /// <summary>
            /// parse name=value pairs from parameter string
            /// </summary>
            /// <returns></returns>
            private static string[] GetQueryStringParameters()
            {
                string query = string.Empty;
                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    if (ApplicationDeployment.CurrentDeployment.ActivationUri != null)
                        query = HttpUtility.UrlDecode(
                            ApplicationDeployment.CurrentDeployment.ActivationUri.Query);
                }
                else
                {
                    var _params = Environment.GetCommandLineArgs();
                    if (_params.Length > 1)
                        query = HttpUtility.UrlDecode(_params[1]);
                }
    
                string[] arguments = null;
                if (!string.IsNullOrWhiteSpace(query) && query.StartsWith("?")) 
                {
                    arguments = query.Substring(1).Split('&'); 
                }
    
                if (!string.IsNullOrWhiteSpace(query) && (arguments == null || arguments.Length == 0))
                    throw new Exception(
                        string.Format(
                            @"exception while decoding params: ""{0}"" ", query));
    
                return arguments;
            }
        /// <summary>
        /// decode "name"="value" pairs into hashtable
        /// </summary>
        /// <returns></returns>
        private static Hashtable _decodeParams(ICollection<string> pParams)
        {
            var result = new Hashtable(pParams.Count);
            foreach (var t in pParams)
            {
                string[] sParamAndValue = t.Split('=');
                if (sParamAndValue.Length > 1)
                {
                    result.Add(sParamAndValue[0], sParamAndValue[1]);
                }
            }
            return result;
        }
