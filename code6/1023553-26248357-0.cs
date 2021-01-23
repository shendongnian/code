    var keys = Observable.FromEventPattern<KeyPressEventArgs>(form, "KeyPress");
    var slides = (from key in keys
                  where key.EventArgs.KeyCode == KeyCode.Space
                  select key)
                 .Publish(spaces => 
                  {
                    var images = GetImages().GetEnumerator();
                    return spaces.TakeUntil(from _ in spaces
                                            where !images.MoveNext()
                                            select Unit.Default)
                                 .Select(_ => images.Current);
                  });
