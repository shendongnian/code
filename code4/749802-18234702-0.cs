       public List<string> Members()
        {
            List<string> propNames = new List<string>();
            foreach (var prop in v.GetType().GetProperties())
            {
                propNames.Add(prop.Name);
            }
        }
