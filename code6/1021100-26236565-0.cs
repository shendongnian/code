    protected override NancyInternalConfiguration InternalConfiguration
    {
        get
        {
            return NancyInternalConfiguration
                  .WithOverrides(nic =>
                  {
                      ...
                      nic.Serializers.Clear();
                      nic.Serializers.Insert(0, typeof(JsonNetSerializer));
                  });
        }
    }
