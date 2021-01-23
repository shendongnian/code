        public static IObservable<string> ReadLineObservable(this TextReader reader)
        {
            return Observable.FromAsync(() => reader.ReadLineAsync())
                .Repeat()
                .TakeWhile(x => x != null);
        }
