    [HttpPost]
    public SaveResult SaveWithSpecialValidation(JObject saveBundle) {
      // custom tag passed from the client
      var theTag = ContextProvider.SaveOptions.Tag;
      ContextProvider.BeforeSaveEntitiesDelegate = BeforeSaveWithException;
      return ContextProvider.SaveChanges(saveBundle);
    }
    private Dictionary<Type, List<EntityInfo>> BeforeSaveWithException(Dictionary<Type, List<EntityInfo>> saveMap) {
      List<EntityInfo> orderInfos;
      if (saveMap.TryGetValue(typeof(Order), out orderInfos)) {
        if (YourErrorCheckHere(orderInfos)) {
          var errors = orderInfos.Select(oi => {
            return new EFEntityError(oi, "WrongMethod", "My custom exception message",        "OrderID");
          });
          // This is a special exception that will be forwarded correctly back to the client.
          var ex =  new EntityErrorsException("test of custom exception message", errors);
          // if you want to see a different error status code use this.
          // ex.StatusCode = HttpStatusCode.Conflict; // Conflict = 409 ; default is Forbidden (403).
          throw ex;
        }
      }
      return saveMap;
    }
