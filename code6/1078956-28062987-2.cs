    private IObservable<IReadOnlyDictionary<string, IUpdate>> CreateUpdateStreams(Product product)
        {
            var dictionary = new Dictionary<string, IUpdate>();
             return
              product.Codes.Select(
                  code => CreateUpdateStream(code).Select(update => new {Update = update, Code = code}))
                  .Merge()
                  .Do(element => dictionary.Add(element.Code, element.Update))
                  .Select(_ => dictionary);
        }
