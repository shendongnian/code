    if (!foundFolders.Contains(xelem))
    {
        list[i].DescendantsAndSelf().Last().Add(file);
        FilesInProject.Descendants("folder")
           .Where(item => item.Attribute("foldername").Value == xelem.FirstAttribute.Value).FirstOrDefault()
           .Add(list[i]);
    }
    else if (i == list.Length-1)
    {
        FilesInProject.Descendants("folder")
           .Where(item => item.Attribute("foldername").Value == xelem.FirstAttribute.Value).FirstOrDefault()
           .Add(file);
    }
