    // Just change the order from Count - 1 down to 0 
    for (int i = ObjectManager.Instance.Objects.Count - 1; i >= 0; --i)
    {
       if (ObjectManager.Instance.Objects[i] is Asteroid)
       {
          ObjectManager.Instance.Objects.Remove(ObjectManager.Instance.Objects[i]);
       }
    }
