    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using System.Collections.Generic;
    //Example for Details.
    if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var role = await RoleManager.FindByIdAsync(id);
      // Get the list of Users in this Role
      var users = new List<ApplicationUser>();
      // Get the list of Users in this Role
      foreach (var user in UserManager.Users.ToList())
      {
        if (await UserManager.IsInRoleAsync(user.Id, role.Name))
        {
          users.Add(user);
        }
      }
      ViewBag.Users = users;
      ViewBag.UserCount = users.Count();
      return View(role);
