     public class Node
            {
                public string NodeType = "";
                public List<Attribute> Attributes;
                public List<Relationship> ParentRelationships;
                public List<Relationship> ChildRelationships;
                public Node(string nodeType)
                {
                    NodeType = nodeType;
                    Attributes = new List<Attribute>();
                    ParentRelationships = new List<Relationship>();
                    ChildRelationships = new List<Relationship>();
                }
    
                public void AddAttribute(Attribute attribute)
                {
                    //We are not allowing empty attributes
                    if(attribute.GetValue() != "")
                        this.Attributes.Add(attribute);
                }
    
                public string GetIdentifier()
                {
                    foreach (Attribute a in Attributes)
                    {
                        if (a.IsIdentifier)
                            return a.GetValue();
                    }
                    return null;
                }
    
                public void AddParentRelationship(Relationship pr)
                {
                    ParentRelationships.Add(pr);
                }
    
                public void AddChildRelationship(Relationship cr)
                {
                    ChildRelationships.Add(cr);
                }
    
      public class Attribute
            {
                private string Name;
                private string Value;
                public bool IsIdentifier;
    
                public Attribute(string name, string value, bool isIdentifier)
                {
                    SetName(name);
                    SetValue(value);
                    IsIdentifier = isIdentifier;
                }
    
                public void SetName(string name)
                {
                    Name = name.Trim();
                }
                public void SetValue(string value)
                {
                    Value = value.Trim();
                }
                public string GetName()
                {
                    return Name;
                }
                public string GetValue()
                {
                    return Value;
                }
    
            }
