        private String path = "pathTo.json";
        public List<MailItem> GetMailItems()
        {
            if (!File.Exists(path))
                File.WriteAllText(path, "[]"); //returns an empty list
            String json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<MailItem>>(json);
        }
