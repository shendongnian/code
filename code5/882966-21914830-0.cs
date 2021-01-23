    internal interface IProjectTag{};
    internal class ProjectService: IProject,IProjectTag{
    public void SetPath
     {
        if (this is IProjectTag)
            {...}
     }
    }
  
