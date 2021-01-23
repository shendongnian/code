    public void Start()
    {
      ProductSearchResult[] results = products.AsParallel().AsOrdered()
          .WithCancellation(cts.Token).WithDegreeOfParallelism(2)
          .Select(product => RetrieveProductAvailability(product.ID, cts.Token))
          .ToArray();
      // Logic for waiting on indiviaul tasks and reporting results
    }
