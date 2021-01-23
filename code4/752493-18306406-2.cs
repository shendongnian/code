    public class ArgumentInfo
    {
       public string Name { get; set; }
       public double Value { get; set; }
    }
    public double ComputeNode(XElement node, params ArgumentInfo[] args)
    {
            var operands = node.Elements().ToList();
            if (operands.Count == 0)
            {
                if (node.Name != "operand") throw new ArgumentException("XML formula error! Please check it");
                ArgumentInfo o = args.FirstOrDefault(x => x.Name == node.Attribute("value").Value);
                return o == null ? double.Parse(node.Attribute("value").Value) : o.Value;
            }    
            if (operands.Count != 2) throw new ArgumentException("XML formula error! Please check it");    
            var a = ComputeNode(operands[0], args);
            var b = ComputeNode(operands[1], args);
            if (node.Name == "add") return a + b;
            else if (node.Name == "sub") return a - b;
            else if (node.Name == "mul") return a * b;
            else return a / b;            
    }
    public double Compute(string xmlFormula, params ArgumentInfo[] args)
    {
            XDocument doc = XDocument.Parse(xmlFormula);
            return ComputeNode(doc.Root, args);
    }
    public double ComputeFormulaFromPath(string xmlFormulaPath, params ArgumentInfo[] args)
    {
            XDocument doc = XDocument.Load(xmlFormulaPath);
            return ComputeNode(doc.Root, args);
    }
    //Example f(x,y) = (x + y - x/y) * (x-y) / 5 with (x,y) = (10,20)
    var result = Compute(@"E:\yourFormula.xml", new ArgumentInfo {Name = "x", Value = 10}, new ArgumentInfo {Name="y",Value=20});//The result is -59
