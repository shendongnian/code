      public string Checker(int Id)
        {
            var dataContext = new PetaPoco.Database("MessageEntity");
            var jsonOLD = dataContext.SingleOrDefault<OldData>("Select OldJson from MakerChecker2 where MakerCheckerId=@0", Id);
            var jsonNEW = dataContext.SingleOrDefault<NewData>("Select NewJson from MakerChecker2 where MakerCheckerId=@0", Id);
            var modelName = dataContext.SingleOrDefault<NameOfModel>("Select ModelName from MakerChecker2 where MakerCheckerId=@0", Id);
            
            MakerCheckerModel mcmodel = new MakerCheckerModel();
            mcmodel.OldJson = jsonOLD.OldJson;
            mcmodel.NewJson = jsonNEW.NewJson;
            mcmodel.ModelName = modelName.ModelName;
            var modelname = mcmodel.ModelName;
            string fullName = "MessageCompose.Models." + modelname;
            Type type = Type.GetType(fullName);
            Object obj = (Activator.CreateInstance(type));
            dynamic olduser = JsonConvert.DeserializeObject(mcmodel.OldJson,obj.GetType());
            dynamic newuser = JsonConvert.DeserializeObject(mcmodel.NewJson,obj.GetType());
    }
