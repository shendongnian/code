        int general = 0;
        int indepth = 0;
        List<Task> queryTasks = new List<Task>
            {
                new Task(() =>
                {
                    general = (from a in ctx.Interactions
                        select new {}).Count();
                }),
                new Task(() =>
                {
                    indepth = (from a in ctx.Interactions
                        select new {}).Count();
                })
            };
        Parallel.ForEach(queryTasks, q => q.RunSynchronously());
        Task.WaitAll(queryTasks.ToArray());
        AddQuarterlyInfo("# of General Inquiries", "1.1", general);                 
        AddQuarterlyInfo("# of In-Depth Counselling and Information Services Interviews", "1.2", indepth);
