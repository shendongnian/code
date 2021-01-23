		var item = doc.Element("user");
		
		var data = new
		{
			user = item.Element("username").Value,
			clientToken = item.Element("clientToken").Value,
			accessToken = item.Element("accessToken").Value,
			userUUID = item.Element("userUUID").Value,
			passLength = item.Element("lengthOfPass").Value
		};
			
		details = data.ToString();
