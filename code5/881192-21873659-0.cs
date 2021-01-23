    foreach (var file in files)
    {
        var groupedResources = from r in resources
                               join f in file.Resources on r.File equals f
                               from childResource in r.Resources
                               from fileResource in resources
                               from parentResource in fileResource.Resources
                               where fileResource.File == file.Name
                               group childResource by new { parentResource, IsStart = childResource.StartsWith(parentResource) } into g
                               where g.Key.IsStart
                               select new { Parent = g.Key.parentResource, Children = g };
        foreach (var grouping in groupedResources)
        {
            Console.WriteLine("{0}", grouping.Parent);
            foreach (var child in grouping.Children)
            {
                Console.WriteLine("\t{0}", child);
            }
        }
    }
