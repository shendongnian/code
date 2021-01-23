    public int CompareTo(object obj)
    {
        var objAsAnimal = obj as Animal;
    
        if (objAsAnimal == null) 
        {
            return 1;
        }
        else
        {
            return this.Name.CompareTo(objAsAnimal.Name);
        }
    }
