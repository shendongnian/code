    public CategoryModel ToModel()
    {
        CategoryModel model = new CategoryModel();
        model.Id = this.Id;
        model.Name = this.Name;
        model.Parent =  this.Parent==null?null:this.Parent.ToModel();  // reference one
        model.Description = this.Description;
        model.Children = new List<CategoryModel>();
        foreach (var child in Children)
        {
           model.Children.Add(child.ToModel()); // reference two
        }
        return model;
    }
