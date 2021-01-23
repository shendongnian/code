    var project = new Project(@"..\..\StackOverflow.csproj");
            var projectItems = project.GetItems("None");
            foreach (var projectItem in projectItems)
            {
                var projectMetadata = projectItem.GetMetadata("CopyToOutputDirectory");
            }
            projectItems = project.GetItems("Resources");
