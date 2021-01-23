    public class Project
    {
         public int Id;
         public List<Project> Dependencies; 
         public List<Project> AddDepedency(List<Project> dependencies){
              dependencies.ForEach(d => {
                   if (Dependencies.All(x=> x.Id != d.Id)){
                        Dependencies.Add(d);
                   }
              });
              return Dependencies;
         }
         public List<Project> RemoveDepedency(List<Project> dependencies){
              dependencies.ForEach(d => {
                   if (Dependencies.Any(x=> x.Id == d.Id)){
                        Dependencies.Remove(d);
                   }
              });
              return Dependencies;
         }
         public List<Project> UpdateDependency(List<Project> dependencies){
              dependencies.ForEach(d => {
                   if (Dependencies.All(x=> x.Id != d.Id)){
                        Dependencies.Add(d);
                   }
              });
              Dependencies.RemoveAll(d => depdencies.All(x => x.Id != d.Id));
              return Depdendencies;
         }
    }
