    private static Project getSolutionSubFolder(Solution2 solution, string subfolder)
    {
        return 
            solution
                .Projects
                .Cast<Project>()
                .FirstOrDefault(
                p => string.Equals(p.Name, subfolder, StringComparison.Ordinal));
    }
