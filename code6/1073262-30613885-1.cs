    public List<ItemViewModel> CreateItemsViewModel(List<Item> items)
        {
            var list = new List<ItemViewModel>();
            foreach (var item in items)
                list.Add(new ItemViewModel()
                {
                    MenuName = item.MenuName,
                    Icon = item.Icon,
                    PageType = item.PageType,
                    ItemTappedCommand = new Command<Type>((type) =>
                    {
                        OpenPageOfType(type);
                    })
                });
            return list;
        }
