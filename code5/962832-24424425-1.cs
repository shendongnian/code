        [WebMethod(EnableSession = true)]
        public static string googleAutoComplete(string Element)
        {
            string result = "";
            List<string> lstReturnGoogle = AsyncHelpers.RunSync<List<string>>(() => getAutoComplete(Element));
            if (lstReturnGoogle != null)
            {
                result = "[";
                foreach (string t in lstReturnGoogle)
                {
                    result += '"' + t + '"' + ',';
                }
                result = result.Remove(result.Length - 1, 1);
                result += "]";
                result.Replace('\\', ' ');
            }
            return result;
        }
