      public static ObservableCollection<Category> GetCategoryData()
        {
            ObservableCollection<Category> data = new ObservableCollection<Category>();
            Category UK = new Category("UK", null);//Because it's root panel it has no parents so parent should set to null
            //Adding sub category of UK
            Category London = new Category("London", UK);
            UK.AddChild(London);
            Category NewCastel = new Category("NewCastel", UK);
            UK.AddChild(NewCastel);
            Category LiverPool = new Category("LiverPool", UK);
            UK.AddChild(LiverPool);
            //adding childs of London and  Newcastle
            for (int i = 1; i <= 100; i++)
            {
                London.AddChild(new Category("london " + i.ToString(), London));
            }
            NewCastel.AddChild(new Category("NewCastle 1", NewCastel));
            NewCastel.AddChild(new Category("NewCastle 2", NewCastel));
            NewCastel.AddChild(new Category("NewCastle 3", NewCastel));
            data.Add(UK);
            Category USA = new Category("USA", null);
            USA.AddChild(new Category("NewYork", USA));
            USA.AddChild(new Category("California", USA));
            data.Add(USA);
            Category China = new Category("China", null);
            China.AddChild(new Category("one", China));
            China.AddChild(new Category("two", China));
            China.AddChild(new Category("three", China));
            data.Add(China);
            return data;
        }
