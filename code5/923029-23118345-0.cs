    Class Recipe {
      private static List<string> names=new List<string>();
       private string name;
     Public String Name {get{return name;}
     set{
    foreach(string nam in names) 
    {
    if(nam==value)//tell the user to try another name
    else{  name=value;names.Add(name);}
    }
    
    }
    }
    
      Public int difficulty_level {get; set;}
      Public List<string> Ingredients = new List<string>();
      Public Recipe (string name) {Name = name;}
    }
    
    Class RecipeBook {
      Public List<Recipe> RecipeList = new List<Recipe>();
      Public AddRecipe {RecipeList.Add (AssignUniqueName());}
      Public RecipeBook() { }
    }
