    void Main()
    {
        var xDoc = XDocument.Load(@"C:\PathToXml\instructions.xml");
        
        foreach (var processor in xDoc.Root.Elements())
        {
            if (processor.Attribute("Name").Value == "ReadValue")
            {
                var readValueProcessor = new ReadValueProcessor();
                readValueProcessor.Execute(processor);
            }
        }
    }
    
    interface IObj
    {
        string Read(int resultid, int locationid);
        void Write(int resultid, int locationid, string text);
    }
    
    class ObjectA : IObj
    {
        public string Read(int resultid, int locationid)
        {
            return resultid + " " + locationid + " From A";
        }
        
        public void Write(int resultid, int locationid, string text)
        {
            Console.WriteLine(resultid + " " + locationid + " From A : " + text);
        }
    }
    
    class ObjectB : IObj
    {
        public string Read(int resultid, int locationid)
        {
            return resultid + " " + locationid + " From B";
        }
        
        public void Write(int resultid, int locationid, string text)
        {
            Console.WriteLine(resultid + " " + locationid + " From B : " + text);
        }
    }
    
    class ReadValueProcessor
    {
        public void Execute(XElement processorNode)
        {
            var typeAttribute = processorNode.Attribute("Type").Value;
            IObj objectToExecute = null;
            
            if (typeAttribute == "ObjectA")
            {
                objectToExecute = new ObjectA();
            }
            else if (typeAttribute == "ObjectB")
            {
                objectToExecute = new ObjectB();
            }
            
            foreach (var action in processorNode.Elements())
            {
                if (action.Name == "Read")
                {
                    var resultid = int.Parse(action.Attribute("resultid").Value);
                    var locationid = int.Parse(action.Attribute("locationid").Value);
                    var result = objectToExecute.Read(resultid, locationid);
                    Console.WriteLine(result);
                }
                else if (action.Name == "Write")
                {
                    var resultid = int.Parse(action.Attribute("resultid").Value);
                    var locationid = int.Parse(action.Attribute("locationid").Value);
                    var text = action.Value;
                    objectToExecute.Write(resultid, locationid, text);
                }
            }
        }
    }
