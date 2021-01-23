    var xml = "...";
    var xDoc = XDocument.Parse(xml);
    var enteredUsername = "tommy";
    var qa = xDoc.Descendants("id")
    				.Where(id => id.Attribute("username").Value == enteredUsername)
    				.Select(id => new { 
    					Question = id.Attribute("question").Value,
    					Answer = id.Attribute("answer").Value})
    				.Single();
    Console.WriteLine(qa.Question);
    Console.WriteLine(qa.Answer);
