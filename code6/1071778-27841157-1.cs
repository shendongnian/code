    using System.Web.Mvc;
    using MyProject.Models;
    using Umbraco.Web.Mvc;
    
    namespace MyProject.Controllers
    {
        public class MemberController : SurfaceController
        {
            public ActionResult SignUp(MemberModel model)
            {
                if (!ModelState.IsValid) 
                    return CurrentUmbracoPage();
    
                var memberService = Services.MemberService;
                if (memberService.GetByEmail(model.Email) != null)
                {
                    ModelState.AddModelError("", "Member already exists");
                    return CurrentUmbracoPage();
                }
                var member = memberService.CreateMemberWithIdentity(model.Email, model.Email, model.Name, "MyMemberType");
    
                memberService.Save(member);
    
                memberService.SavePassword(member,model.Password);
    
                Members.Login(model.Email, model.Password);
    
                return Redirect("/");
            }
        }
    }
