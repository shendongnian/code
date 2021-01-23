 	  [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string Display(int id)
        {
            string[] s = new string[3];
            for (int i = 0; i < 3; i++)
            {
                s[i] = i + "*" + (i + 1) + "*" + (i + 2);
            }
            return string.Format(id.ToString());
        }
