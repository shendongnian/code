    @using Microsoft.AspNet.Identity
    @using Microsoft.AspNet.Identity.EntityFramework
    @using YourWebApplication.Models
    @{
        var phoneNumber= string.Empty;
        var userLanguage = string.Empty;
        if (User.Identity.IsAuthenticated) {
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            var currentUser = manager.FindById(User.Identity.GetUserId());
            phoneNumber = currentUser.PhoneNumber;
            userLanguage = currentUser.Language;
        }
    }
