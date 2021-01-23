            var managingString = new ManagingModel
            {
                Get = new Func<string>(GetString)
            };
            var list = new List<IStorage>();
            list.Add(managingString);
            var get = list[1].Get;
