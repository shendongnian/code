    class SpaceBody...
    {
        ...
        public virtual void CreateGameObject()
        {
            instance = new GameObject();
        }
        ...
    }
    class SpaceBodySystem...
    {
        ...
        public override void CreateGameObject()
        {
            instance = new GameObject();
            foreach(ChildType child in Children)
            {
                child.CreateGameObject();
            }
        }
        ...
    }
    class Star: SpaceBodySytem<SpaceBody>
    {
        ...
        public override void CreateGameObject()
        {
            base.GameObject();
            doExtraWorkForTheStar();
        }
        ...
    }
    StarSystem.CreateObject();
     // for attached file, will load and create one star (Sun) and nine planets.
