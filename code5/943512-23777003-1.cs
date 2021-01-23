    private IEnumerable<IBoat> GetRandomBoatImplementation(IKernel container, int count)
    {
        for (int i = 0; i < count; i++)
        {
            yield return container.ResolveAll<IBoat>()
                                  .OrderBy(item => Guid.NewGuid())
                                  .FirstOrDefault();
        }
    }
