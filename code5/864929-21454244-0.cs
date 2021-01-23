    var designerGenerator = new MigrationDesignerGenerator();
    designerGenerator.Session = new Dictionary<string, object>();
    designerGenerator.Session.Add("Target", scaffold.Resources["Target"]);
    designerGenerator.Session.Add("MigrationId", scaffold.MigrationId);
    designerGenerator.Initialize();
    File.WriteAllText(directory + scaffold.MigrationId + ".Designer.cs", designerGenerator.TransformText());
