    public class SomeServiceClass
    {
        private readonly IUserService _userService;
        public SomeServiceClass(IUserService userService)
        {
            this._userService = userService;
        }
        public void PopulateAudit<T>(this T entity)
            where T: IEntity
        {
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdateUserID = this._userService.GetCurrentUser();
        }
    }
    a = Context.accounts.FirstOrDefault(x => x.id == dto.Id);
    someServiceInstance.PopulateAudit(a);
