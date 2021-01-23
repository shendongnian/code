    public class AppModel {
        public AppModel(IRepository repository) {
            
            var result = (from o in repository.GetOrganizations() select o).FirstOrDefault();
            
            if (result != null) {
                OrgName = result.Name;
            } 
        }
        public string OrgName { get; private set; }
    }
