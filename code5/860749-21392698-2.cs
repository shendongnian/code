    public IList<Model> Items
        {
            get
            {
                IList<Model> items = new List<Model>();
                items.Add(new Model() { Header = "Header 1", Content = "Header 1 content" });
                items.Add(new Model() { Header = "Header 2", Content = "Header 2 content" });
                items.Add(new Model() { Header = "Header 3", Content = "Header 3 content" });
                return items;
            }
        }
