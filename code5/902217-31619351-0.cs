    public class MyNewAssembliesResolver : IAssembliesResolver
    {
        public virtual ICollection<Assembly> GetAssemblies()
        {
            
           var initialAssemblies = System.AppDomain.CurrentDomain.GetAssemblies().ToList();
           var controller = Assembly.LoadFrom(@"C:\Path_To_Controller_Dll");
            initialAssemblies.Add(controller);
           
            return baseAssemblies;
        }
    }
