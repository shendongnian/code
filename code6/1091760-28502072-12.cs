        public void EditMailItem(MailItem mailItem)
        {
            String jsonRead = File.ReadAllText(fullPath);
            List<MailItem> mailItemList = JsonConvert.DeserializeObject<List<MailItem>>(jsonRead);
            int indexOfMailItem = mailItemList.FindIndex(o => o.ID == mailItem.ID); //LINQ
            mailItemList[indexOfMailItem] = mailItem;
            String jsonWrite = JsonConvert.SerializeObject(mailItemList, Formatting.Indented);
            File.WriteAllText(jsonWrite);
        }
