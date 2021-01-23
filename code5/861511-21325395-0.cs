        String preQuery="";
        public void Search(string query)
        {
           if(preQuery==query)
              return;
           Items.Clear();
       
           Items.Add(new Item() { Name = query + " 1" });
           Items.Add(new Item() { Name = query + " 2" });
           Items.Add(new Item() { Name = query + " 3" }); 
        }
