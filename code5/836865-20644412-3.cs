	public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
	{
		...
		foreach (Project project in _applicationObject.Solution.Projects)
		{
			VSProject vsProject = project.Object as VSProject;
			if (vsProject != null)
			{
				foreach (Reference reference in vsProject.References)
				{
					// if it not project reference
					if (reference.SourceProject == null)
					{
						var refPath = reference.Path;
						var refDir = new FileInfo(refPath).Directory;
						// assumes that .csproj file located in two levels upper
						if (refDir.Parent != null && refDir.Parent.Parent != null)
						{
							var possibleProjectDir = refDir.Parent.Parent;
							string[] projFiles = Directory.GetFiles(possibleProjectDir.FullName, "*.csproj");
							if (projFiles.Length == 1)
							{
								Project solProject = FindProjectWithinSolution(projFiles[0]);
								if (solProject != null)
								{
									//replace reference with project reference
									reference.Remove();
									vsProject.References.AddProject(solProject);
								}
							}
						}
					}
				}
			}
		}
		...
	}
	private Project FindProjectWithinSolution(string projectPath)
	{
		foreach (Project project in _applicationObject.Solution.Projects)
		{
			VSProject vsProject = project.Object as VSProject;
			if (vsProject != null)
			{
				if (vsProject.Project.FullName == projectPath)
				{
					return project;
				}
			}
		}
		return null;
	}
