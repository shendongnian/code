    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string CreatedById { get; set; }
        public ICollection<PostViewModel> Posts { get; set; }
        public string CreatedByUserName { get; set; } // end self-referencing
    }
    public class PostViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string CreatedById { get; set; }
        public string CreatedByUserName { get; set; } // end self-referencing
    }
    public JsonResult Get()
    {
        try
        {
            using (var uow = new UnitOfWork<SkipstoneContext>())
            {
                var service = new UserService(uow, User.Identity.GetUserId(), this.CompanyId);
                var u = service.GetAll("MemberOf");
                var vm = Mapper.Map<UserViewModel[]>(u);
                return new JsonResult { Data = new { success = true, users = vm } }; // Return our users
            }
        }
        catch (Exception ex)
        {
            return new JsonResult { Data = new { success = false, error = ex.Message } };
        }
    }
