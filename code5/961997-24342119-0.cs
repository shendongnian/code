        [WebMethod()]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string Test(string Message)
        {
            return Message;
        }
