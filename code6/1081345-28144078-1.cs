        public static void Main()
        {
            string json = @"{here your json}";
            RootObject m = JsonConvert.DeserializeObject<RootObject>(json);
            Console.WriteLine(m.realm.name.Trim());
        }
