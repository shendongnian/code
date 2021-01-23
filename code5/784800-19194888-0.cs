        public List<string> Items;        
    
        public void getItemsFromTextBox(TextBox textbox)
        {
            if(null == Items)
            {
              Items = new List<string>();
            }
            foreach (string item in textbox.Text.Split('\n'))
            {
                if (!String.IsNullOrWhiteSpace(item))
                    Items.Add(item);
            }
        }
