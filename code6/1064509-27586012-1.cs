    Dictionary<int, Action<float>> actions = new Dictionary<int, Action<float>>();
    actions[idle] = TakeDamage_Idle;
    actions[walk] = TakeDamage_Walk;
    …
    
    public void TakeDamage(float damage)
    {
      actions[state](damage);
    }
