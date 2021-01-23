        System.AddIn.Contract.IListContract<string> IThemeContract.ResourceDictionaries
        {
            get
            {
                var list = new List<string>();
                foreach (var s in _view.ResourceDictionaries)
                {
                    list.Add(XamlWriter.Save(s));
                }
                return CollectionAdapters.ToIListContract<string>(list);
            }
        }
