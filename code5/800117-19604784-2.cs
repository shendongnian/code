        public void AddProduct(object obj)
        {
            var workspace = new ProductViewModel();
            Workspaces.Add(workspace);
            SelectedTab = workspace;
        }
