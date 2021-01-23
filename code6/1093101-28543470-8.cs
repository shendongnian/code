    //Returns the path of the this container prepending all parent indeces
    public string GetPath()
	{
		string ret = "";
		if (_parent != null)
		{
			ret = _parent.GetPath();
			ret += String.Format("{0}.", Index);
		}
		return ret;
	}
    //Gets a child ensuring all container lists contain enough elements
	public Container GetChild(string indexPath)
	{
		string[] pathParts = indexPath.Split(new[] { '.' }, 2);
		if (pathParts.Any())
		{
			int index;
			if (int.TryParse(pathParts[0], out index))
			{
				//make sure there's enough containers
				Containers = Enumerable.Range(0, index +1).Select(i => new Container(this,i)).ToList();
				if (pathParts.Count() == 2)
				{
					//more sub children so recursively add...
					return Containers[index].GetChild(pathParts[1]);
				}
                return Containers[index];
			}
		}
        return null;
	}
