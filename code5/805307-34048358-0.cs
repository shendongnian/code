        public ActionResult Form(int id)
        {
            _repository = new EntityFrameworkRepository<Model>(new EntityContext(), "Id");
            return View(_repository.Where(c => c.Id == id).FirstOrDefault() == null ? new Model() : _repository.Where(c => c.Id == id).FirstOrDefault());
        }
