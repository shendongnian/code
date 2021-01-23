    public List<dynamic> GetSwimlaneAttribute(List<ProjectSwimlaneAttribute> swimlaneAttributeTable, Dictionary<string, string> dic)
    {
        List<dynamic> swimlaneAttributes = new List<dynamic>(); // modified dynamic to List<dynamic>
        swimlaneAttributes = swimlaneAttributeTable.Select(s => new
        {
            ID = s.Id,
            DataType = s.AttributeDataType,
            IsCriticalField = s.IsCriticalField,
        });
        return swimlaneAttributes;
    }
