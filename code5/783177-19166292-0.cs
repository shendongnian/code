    private DbEntities db = new DbEntities();
    public ActionResult KullaniciYetkiGuncelle(int id = 0)
            {
                ViewModel vm = new ViewModdel();
                vm.categories = GenerateSub(db.Categories.Where(x=>x.ParentCategoryID == null).ToList());
                return View(vm);
            }
