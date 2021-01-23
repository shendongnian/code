        // service layer
        public MyModelB GetMyModelById(int id)
        {
            MyModelRepository r = new MyModelRepository ();
            MyModel model = r.GetMyModelById(id);
            if(model != null) 
            {
                    MyModelB obj = new MyModelB();
                    obj.Id = model.Id;
                    obj.Name = model.Name;
                    obj.CategoryId = model.CategoryId;
            } 
            else return null;
          }
