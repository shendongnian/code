    IEnumerable<string> Proposed_By = 
            from project in xmldoc.Descendants("Projects").Elements("Project")
            where project.Attribute("Country") != null 
                  & project.Attribute("Country").Value == "Canada"
                  & project.Attribute("ProposedBy") != null
            select project.Attribute("ProposedBy").Value;
