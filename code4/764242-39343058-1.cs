     var reader = new ResXResourceReader(@"C:\CarResources.resx");//same fileName
     var node = reader.GetEnumerator();
     var writer = new ResXResourceWriter(@"C:\CarResources.resx");//same fileName(not new)
     while (node.MoveNext())
             {
         writer.AddResource(node.Key.ToString(), node.Value.ToString());
           }
      var newNode = new ResXDataNode("Title", "Classic American Cars");
      writer.AddResource(newNode);
      writer.Generate();
      writer.Close();
