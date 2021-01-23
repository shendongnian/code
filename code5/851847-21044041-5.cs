    public class UserController : EntityController<UserManagementContext>
    {
        public async Task<ActionResult> SomeMethod(){
            ......
            var user = await DB.FindByNameAsync(userName);
            ......
        }
    }
