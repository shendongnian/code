    //in the fields section of some class
    Model myModel;
    //in an initialization or loadContent method of the same class
    myModel = LoadMyModel(name, Content);
    //load & draw methods that can be called any time as long as they are in scope
    Model LoadMyModel(string name, ContentManager content)
    {
      return content.Load<Model>(name);
    }
        
    void DrawModel(Model myModel, Matrix worldTransform, Matrix view, Matrix projection)
    {
       myModel.Draw(worldTransform, view, projection);
    }
