    public bool Insert(Project project)
    {
	bool gotInserted = true;
	
	if (IsInList(project) == true)
	{
		gotInserted = false;
	}
	else
	{
		Node tmp = this._head;
		while(project.id < tmp.Project.id)
		{
			tmp = tmp.Next;
		}
		this._head = new Node();
		this._head.Project = project;
		this._head.Next = tmp;
	}
	
	return gotInserted;
    }
