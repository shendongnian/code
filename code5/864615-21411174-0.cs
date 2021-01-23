    private void AddObject(GameObjectBase obj, int times, Func<Vector3> getPosition)
    {
        for (int i = 0; i < times; i++)
        {
            Vector3 tempPos = getPosition();
    
            AddObject(obj, tempPos);
        }
    }
