        public void LoadMetadataResource<DALType, K, V>(IDictionary<K, V> list, string resource) where DALType: DALObject
        {
            ++activeLoads;
            var parameters = new SortedDictionary<string, string>();
            parameters.Add("table", resource);
            SendAPICall("tables", parameters, (successResponse) =>
                {
                    list = JsonMapper.ToObject<List<DALType>>(successResponse).ToDictionary(temp => (K)temp.Id(), temp => (V)temp.Instantiate());
                    --activeLoads;
                }, (errorResponse) =>
                {
                    --activeLoads;
                });
        }
