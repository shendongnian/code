    var dir = parentDir.CreateSubdirectory("test");
    var ac = dir.GetAccessControl();
    ac.AddAccessRule(newRule);
    foreach (FileSystemAccessRule rule in explicitRules)
        ac.AddAccessRule(rule);
    dir.SetAccessControl(ac);
