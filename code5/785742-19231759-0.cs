    protected override Dictionary<Type, List<EntityInfo>> BeforeSaveEntities(Dictionary<Type, List<EntityInfo>> saveMap) {
       foreach (var type in saveMap.Keys) {
         var list = saveMap[type];
          foreach (var entityInfo in list) {
             var entity = entityInfo.Entity;
             // .. do something interesting here
          }
     }
