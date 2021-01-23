            //build dictionary
            Dictionary<string, object> Input = new Dictionary<string, object>();
            Input.Add("Value1", "One");
            Input.Add("Value2", "Two");
            Input.Add("Value3", 3);
            Input.Add("Date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //Serialize!
            Serialize(FilePath, Input);
