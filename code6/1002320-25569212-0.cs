	private void createNode(string body, string senderid, string receiverid,DateTime creationDate,string path1,string path2)
	{
		XDocument doc1 = XDocument.Load(path1);
		XDocument doc2 = XDocument.Load(path2);
		string receiver = "Friend_"+receiverid;
		string sender = "Friend_"+senderid;
		XElement root1 = doc1.Element(receiver);
		if (root1 == null)
		{
			root1 = new XElement(receiver);
			doc1.Add(root1);
		}
		XElement root2 = doc1.Element(sender);
		if (root2 == null)
		{
			root2 = new XElement(sender);
			doc2.Add(root2);
		}
		root1.Add(new XElement("MESSAGE_BODY", body));
		root1.Add(new XElement("MESSAGE_SENDER_ID", senderid));
    	root1.Add(new XElement("MESSAGE_RECEIVER_ID", receiverid));
    	root1.Add(new XElement("MESSAGE_CREATION_DATE", creationDate));
    	root2.Add(new XElement("MESSAGE_BODY", body));
    	root2.Add(new XElement("MESSAGE_SENDER_ID", senderid));
    	root2.Add(new XElement("MESSAGE_RECEIVER_ID", receiverid));
    	root2.Add(new XElement("MESSAGE_CREATION_DATE", creationDate));
    	doc1.Save(path1);
    	doc2.Save(path2);
	}
