    public class Project
    {
         public int Id;
         public List<ProjectDependency> Dependencies; 
         public List<ProjectDependency> AddDepedency(List<ProjectDependency> dependencies){
              dependencies.ForEach(d => {
                   if (Dependencies.All(x=> x.Id != d.Id)){
                        Dependencies.Add(d);
                   }
              });
              return Dependencies;
         }
         public List<ProjectDependency> RemoveDepedency(List<ProjectDependency> dependencies){
              dependencies.ForEach(d => {
                   if (Dependencies.Any(x=> x.Id == d.Id)){
                        Dependencies.Remove(d);
                   }
              });
              return Dependencies;
         }
         public List<ProjectDependency> UpdateDependency(List<ProjectDependency> dependencies){
              dependencies.ForEach(d => {
                   if (Dependencies.All(x=> x.Id != d.Id)){
                        Dependencies.Add(d);
                   }
              });
              Dependencies.RemoveAll(d => depdencies.All(x => x.Id != d.Id));
              return Depdendencies;
         }
    }
