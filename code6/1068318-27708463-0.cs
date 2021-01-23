    SortedSet<Project> prioritizedProjects = new SortedSet<Project>(new CompareProjByPriority());
    ...
    Project rePrioritize = ...;
    prioritizedProjects.Remove(rePrioritize);
    rePrioritize.Priority = 1;
    prioritizedProjects.Add(rePrioritize);
