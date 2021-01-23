    var tasks = objectsList
                .Where(x => x.Something() > 0)
                .Select(x => {
                                var task = Task.Factory.StartNew(() => x.RunObject());
                                task.ContinueWith(t => ChangeObject(....));
                                return task;
                             })
                .ToArray();
        Task.WaitAll(tasks);
