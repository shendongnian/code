            List<ProjectKey> projectKeys = new List<ProjectKey>();
            projectKeys.Add(new ProjectKey("text", true));
            projectKeys.Add(new ProjectKey("text.ui", true));
            projectKeys.Add(new ProjectKey("text.ui.hello", false));
            projectKeys.Add(new ProjectKey("text.ui.goodbye", false));
            projectKeys.Add(new ProjectKey("text.ui.popup", false));
            projectKeys.Add(new ProjectKey("text.ui.project", true));
            projectKeys.Add(new ProjectKey("text.ui.project.val", false));
            projectKeys.Add(new ProjectKey("text.ui.project.val2", false));
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < projectKeys.Count; i++)
            {
                if (projectKeys[i].Parent)
                {
                    // If current key is parent - do not close bracket.
                    output.AppendLine(string.Format("\"{0}\": {{", projectKeys[i].Key.Split('.').Last()));
                }
                else
                {
                    // If this is no ones parent - close bracket.
                    output.AppendLine(string.Format("\"{0}\": \"\"", projectKeys[i].Key.Split('.').Last()));
                }
            }
            // Append as many closing brackets as there are many parents.
            for (int i = 0; i < projectKeys.Where(x => x.Parent).Count(); i++)
            {
                output.AppendLine("}");
            }
            Console.Write(output.ToString());
