        public void AddMailItem(MailItem mailItem)
        {
            String json = File.ReadAllText(fullPath);
            List<MailItem> mailItemList = JsonConvert.DeserializeObject<List<MailItem>>(json);
                if (mailItemList == null)
                    mailItemList = new List<MailItem>();
            mailItemList.Add(mailItem);
            String json = JsonConvert.SerializeObject(mailItemList, Formatting.Indented);
            File.WriteAllText(json);
        }
