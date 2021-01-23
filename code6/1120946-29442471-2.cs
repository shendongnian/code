        // service layer
        public void Add(MyModelB model)
        {
            MyModel obj = new MyModel();
            obj.Id = model.Id;
            obj.Name = model.Name;
            obj.CategoryId = model.CategoryId;
    
            MyModelRepository r = new MyModelRepository ();
            r.Add(obj);
        }
