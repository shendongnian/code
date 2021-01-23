            public DataSourceResult Read(DataSourceRequest request)
            {
                var result = _dataService.Read().AsQueryable().ToDataSourceResult(request);
                return result;
            }
    
            public void Update(ProductTitlePartsBySku item)
            {
                _dataService.Update(item);
                Clients.Others.update(item);
            }
