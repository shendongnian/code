        private StringKeyValueIncrementalCollection categories;
        private StringKeyValueIncrementalCollection allCategories;
        public StringKeyValueIncrementalCollection Categories
        {
            get { return categories; }
            set
            {
                filteredCategories = value;
                RaisePropertyChanged("Categories");
            }
        }
        public async void LoadCategories()
        {
            List<StringKeyValue> temp = await this.openVlaanderenService.GetCategoriesData();
            allCategories = new StringKeyValueIncrementalCollection(temp);
            Categories = allCategories;
        }
