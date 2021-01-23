    public List<Group> ReadGroupsFromXmlFile(string fileName)
    {
        var groupsXml = new GroupsXml();
        var groupsXmlFile = xDocument.Load(fileName).ToString();
        var groupType = groupsXml .GetType();
        var oXmlSerializer = new XmlSerializer(groupType);
        groupsXml = (GroupsXml)oXmlSerializer.Deserialize(new StringReader(groupsXmlFile ));
                return categoriesXml.GroupsList;
    }
