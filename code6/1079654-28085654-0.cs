	var newData = new LinkedList<KeyValuePair<string, string>>();
	Nullable<KeyValuePair<string,string>> previousNode = null;
	string valueToFind = "$2";
	string valueToReplace = null;
	foreach(var currentNode in data)
	{
		if(previousNode != null)
		{
			if(previousNode.Value.Key == "LOAD" && currentNode.Key == "STORE")
			{
				valueToReplace = previousNode.Value.Value;
			}
		}
		
		if(valueToReplace != null && currentNode.Value == valueToFind)
		{
			var newValue = new KeyValuePair<string,string>(currentNode.Key, valueToReplace);
			newData.AddLast(newValue);
		}
		else
		{
			newData.AddLast(currentNode);
		}
	
		previousNode = currentNode;
	}
