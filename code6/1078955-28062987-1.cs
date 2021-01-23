    private IObservable<IDictionary<string, IUpdate>> CreateUpdateStreams(Product product)
        {
            var dictionary = new Dictionary<string, IUpdate>();
            return
                product.Codes.Select(
                    code => CreateUpdateStream(code).Select(update => new {Update = update, Code = code}))
                    .Merge()
                    .Select(element =>
                    {
                        dictionary.Add(element.Code, element.Update);
                        return new Dictionary<string, IUpdate>(dictionary);
                    });
        }
