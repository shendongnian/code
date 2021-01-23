    [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public ResponseStatistic_3 Statistic_3(string klant)
        {
                Statistic_3[] items = Helper.Helper_Statistic_3(klant).ToArray();
                ResponseStatistic_3 response = new ResponseStatistic_3(items);
    
    
                return response;
        }
