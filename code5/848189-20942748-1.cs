        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public IEnumerable<object> GetAssets()
        {
            using (var db = new assetEntities())
            {
                var results = from a
                              in db.Assets
                              select new
                              {
                                  Id = a.Id,
                                  Name = a.Name,
                                  AssetTypeId = a.AssetTypeId
                              };
                return results;
            }
        }
