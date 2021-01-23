        var MyData = new Dictionary<int, int>();
        MyXml.LoadXml(File.ReadAllText(@"pathOfXml").ToString());
        var MySerialNodes =  MyXml.DocumentElement.SelectNodes("//@SerialNo");
        var MyC1Nodes =  MyXml.DocumentElement.SelectNodes("//@C1");
        If (MyC1Nodes.Count == MySerialNodes.Count)
        {
         
        For(int i = 0; i <MySerialNodes.Count; i++)
        {
        MyData.Add((int)MySerialNodes[i],(int) MyC1Nodes[i]); 
        }
    }
