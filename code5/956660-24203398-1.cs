    var res = col.Find(Query.ElemMatch("Children.Pets", Query.EQ("Name", "Fishy")));
    foreach(var _parent in res)
    {
        foreach (var _child in _parent.Children)
        {
            var pets = _child.Pets;
            if(pets!=null)
            {
                 pets.FirstOrDefault(x => x.Name == "Fishy");
                 if(pet!=null)
                     pet.Name = "Doggy";
            }
        }
        col.Save(_parent);
    }
