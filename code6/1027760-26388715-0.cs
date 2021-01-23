    var batches = foos.Publish(publishedFoos => publishedFoos
      .Scan(
        new { foo = (Foo)null, last = DateTime.MinValue, take = true },
        (acc, foo) =>
        {
          var boundary = foo.Timestamp - acc.last >= TimeSpan.FromSeconds(5);
          return new
          {
            foo,
            last = boundary ? foo.Timestamp : acc.last,
            take = boundary
          };
        })
      .Where(a => a.take)
      .Select(a => a.foo)
      .Publish(boundaries => boundaries
        .Skip(1)
        .StartWith((Foo)null)
        .GroupJoin(
          publishedFoos,
          foo => foo == null ? boundaries.Skip(1) : boundaries,
          _ => Observable.Empty<Unit>(),
          (foo, window) => (foo == null ? window : window.StartWith(foo)).ToList())))
      .Merge()
      .Replay(lists => lists.SkipLast(1)
                            .Select(list => list.Take(list.Count - 1))
                            .Concat(lists),
              bufferSize: 1);
