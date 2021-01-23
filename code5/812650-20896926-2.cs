        [WebGet]
        public string GetMyEntityName(string myEntityKey)
        {
            var model = this.CurrentDataSource.GetDataModel();
            var entity = model.MyEntity.Find(myEntityKey);
            return entity.Name;
        }
