    [HttpPost]
    public JsonResult registration(Solnet_HotelSuite.Models.UserModels user, string userID)
    {
        try
        {   
            if (ModelState.IsValid)
            {
                if (userExist(user.user_name))
                {
                    ViewBag.res = "User exist in record";
    
                    return Json(new { Message = "User Registartion failed" });
                }
                using (var db = new DBEntity()) 
                {
                    var query = (from p in db.RolesModels
                             where p.Caption == userID
                             select p.RoleId).Single();
    
                    var sysUser = db.UserModels.Create();
                    sysUser.user_name = user.user_name;
                    sysUser.user_pass = user.user_pass;
                    sysUser.UserEmail = user.UserEmail;
                    sysUser.RegDate = user.RegDate;
    
                    sysUser.RoleId = query;
                    sysUser.Roles = user.Roles;
                    sysUser.status = user.status;
                    db.UserModels.Add(sysUser);
                    try{
                         db.SaveChanges();
                    }
                    catch (DbEntityValidationException dbEx)
                    {
                         return Json(new { Message = "User Registartion failed" });
                    }      
                }
                using (var db = new DBEntity()) 
                {
                    ViewBag.Roles = db.RolesModels.Select(r => r.Caption);
                    ViewBag.RolesId = db.RolesModels.Select(r => r.RoleId);
                }
                return Json(new { Message = "User Registartion successful"});
            }
            else
                return Json(new { Message = "User Registartion failed" });
        }         
     }
}
