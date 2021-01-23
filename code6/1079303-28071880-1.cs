    public void Start()
    {
      ProductSearchResult[] results = products.AsParallel()
          .WithCancellation(cts.Token).WithDegreeOfParallelism(2)
          .Select(product => RetrieveProductAvailability(product.ID, cts.Token))
          .ToArray();
      // Logic for waiting on indiviaul tasks and reporting results
    }
