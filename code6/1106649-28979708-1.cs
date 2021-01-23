    public ActionResult CreateDetailsMateria(int IdMateriaCurso)
    {
      MateriasViewModel model = new MateriasViewModel();
      // Get the data model and map the properties to the view model
      ....
      
      // Cant understand some of your code so you need to set the values of the following line
      model.SelectedMaestros = new int[] { 2, 4 };
      
      // Assign the select list (this is all that's required!)
      var listaMaterias = new Metodos.Entidades().getAllMaterias();
      model.MaestrosList = new SelectList(listaMaterias, "IdMateriasNombres", "MateriaNombre");
      return View(model)
    }
