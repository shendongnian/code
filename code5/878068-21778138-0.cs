    public class RoleController : Controller
       {
          private IRoleRepository roleRepository;
    
          // This constructor would not be needed if you were to use IOC container
          public RoleController ()
          {
             this.roleRepository = new RoleRepository(new RoleContext());
          }
    
          public RoleController(IRoleRepository studentRepository)
          {
             this.roleRepository = roleRepository;
          }
          ....
