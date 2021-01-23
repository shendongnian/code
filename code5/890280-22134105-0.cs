    DynamicEntity entity = new DynamicEntity("new_holder");
    entity.Properties.Add(new KeyProperty("new_holderid", new Key(guid)));
    entity["field name"] = new CrmNumber(5);
    TargetUpdateDynamic update = new TargetUpdateDynamic();
    update.Entity = entity;
    UpdateRequest request = new UpdateRequest();
    request.Target = update;
    UpdateResponse response = (UpdateResponse)service.Execute(request);
