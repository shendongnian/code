    public abstract class Entity
    {
        public Entity()
        {
            API.FrameUpdateEvent += FrameUpdate;
        }
        public abstract void FrameUpdate(float deltaTime);
    }
