        [System.Web.Services.WebMethod]
        public static string SendParameters(string name, int age)
        {
            if (!String.IsNullOrEmpty(name))
                name = name.First().ToString().ToUpper() + name.Substring(1);
            return string.Format("Name: {0}{2}Age: {1}", name, age, Environment.NewLine);
        }
    }
