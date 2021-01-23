    public ActionResult About()
            {
                //Busca la estacion con Id 12345
                using(ApplicationDbContext context = new ApplicationDbContext())
                {
                    var estacion = context.Estaciones.SingleOrDefault(e => e.NoEstacion == 12345);
                    var userManager = new UserManager<ApplicationUser>
                           (new UserStore<ApplicationUser>(context));
                    var usuario = userManager.FindByName("Ale");
                    estacion.Usuarios = new List<ApplicationUser>() { usuario };
                    context.SaveChanges();
                    ViewBag.Message = "Datos guardados";
                }
                return View();
            }
