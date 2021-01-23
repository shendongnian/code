    public class UserController: Controller {
        [Ninject.Inject]
        public IUserRepository UserRepository { get; set; }
		
        public ActionResult Login(AuthorizationViewModel vm) {
            if(ModelState.IsValid) {
                if(UserRepository.Validate(vm.Email, vm.Password)) {
                    FormsAuthentication.SetAuthCookie(vm.Email, true);
                    if(Url.IsLocalUrl(vm.ReturnUrl)) {
                        return Redirect(vm.ReturnUrl);
                    }
                    else {
                        return RedirectToAction("Page", "Main");
                    }
                }
                else {
                    ModelState.AddModelError("", Resources.Validation.WrongEmailOrPassword);
                }
            }
            return View(vm);
        }
    }
