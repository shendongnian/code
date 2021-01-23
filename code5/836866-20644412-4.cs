	public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
    {
        handled = false;
        LogMessage(string.Format("Start investigation at {0} {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString()));
        if(executeOption == vsCommandExecOption.vsCommandExecOptionDoDefault)
        {
            if(commandName == "ReferenceDoctor.Connect.ReferenceDoctor")
            {
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
                                string refPath = reference.Path;
                                string refAssemblyName = Path.GetFileNameWithoutExtension(refPath);
                                Project refProject = FindProjectWithinSolution(refAssemblyName);
                                // if within solution found project with suitable name
                                if (refProject != null)
                                {
                                    try
                                    {
                                        //replace reference with project reference
                                        reference.Remove();
                                        vsProject.References.AddProject(refProject);
                                        LogMessage(string.Format(" [{0}] Reference to {1} replaced. ({2} -> {3})", vsProject.Project.Name, refAssemblyName, refPath, refProject.FullName));
                                    }
                                    catch (Exception exc)
                                    {
                                        LogMessage(string.Format(" [{0}] ERROR during replacing reference to {1} ({2} -> {3}): {4}", vsProject.Project.Name, refAssemblyName, refPath, refProject.FullName, exc.Message));
                                    }
                                }
                            }
                        }
                    }
                }
                LogMessage(string.Format("Completed at {0} {1}\r\n", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString()));
                handled = true;
                return;
            }
        }
    }
    private Project FindProjectWithinSolution(string projectName)
    {
        foreach (Project project in _applicationObject.Solution.Projects)
        {
            VSProject vsProject = project.Object as VSProject;
            if (vsProject != null)
            {
                if (string.Compare(vsProject.Project.Name, projectName, ignoreCase: true) == 0)
                {
                    return project;
                }
            }
        }
        return null;
    }
