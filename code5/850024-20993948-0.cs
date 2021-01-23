    >   if (DataAccess.DAL.UserIsValid(model.UserName, model.Password))
    >                 
{
    >                     FormsAuthentication.SetAuthCookie(model.UserName, false); 
    >                     return RedirectToAction("Index", "Home",new { username = model.Username } ); //sending the parameter 'username'value to Index //of Home Controller
    >          
       }
