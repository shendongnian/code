    class Program
    {
        static void Main(string[] args)
        {
            var project = CreateProject();
            var newDependencyIds = new List<int>() {2, 3, 4, 13};
            UpdateDependencies(project, newDependencyIds);
        }
        private static Project CreateProject()
        {
            var project = new Project() {Id = 1};
            project.Dependencies = new List<ProjectDependency>();
            for (int projectId = 2; projectId < 10; projectId++)
            {
                var dependency = new ProjectDependency() {Project = project, Dependency = new Project() {Id = projectId}};
                project.Dependencies.Add(dependency);
            }
            return project;
        }
        private static void UpdateDependencies(Project p, List<int> newDependencyIds)
        {
            var oldDependencyIds = p.Dependencies.Select(d => d.Dependency.Id);
            var unchanged = oldDependencyIds.Intersect(newDependencyIds);
            var added = newDependencyIds.Except(oldDependencyIds);
            var removed = oldDependencyIds.Except(newDependencyIds);
            Console.WriteLine("Old ProjectDependency Ids: " + string.Join(", ", oldDependencyIds));
            Console.WriteLine("New ProjectDependency Ids: " + string.Join(", ", newDependencyIds));
            Console.WriteLine();
            Console.WriteLine("Unchanged: " + string.Join(", ", unchanged));
            Console.WriteLine("Added: " + string.Join(", ", added));
            Console.WriteLine("Removed: " + string.Join(", ", removed));
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
