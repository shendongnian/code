          const string projectPath = @"your csproj path";
          var collection = new Microsoft.Build.Evaluation.ProjectCollection {DefaultToolsVersion = "4.0"};
      
          collection.RegisterLogger(new ConsoleLogger());
          collection.LoadProject(projectPath);
          var project = new Microsoft.Build.Evaluation.Project(collection);
             
          if (!project.Build())
          {
             //Error
          }
