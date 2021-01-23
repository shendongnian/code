    var xml = "<userinfo>"
        + "<id username=\"bobby\" password=\"password123\" email=\"booby@gmail.com\" question=\"Favourite colour\" answer=\"blue\"></id>"
        + "<id username=\"tommy\" password=\"adc123\" email=\"herpderp@gmail.com\" question=\"first pets name\" answer=\"arnold\"></id>"
    	+ "</userinfo>";
    var xDoc = XDocument.Parse(xml);
    var enteredUsername = "tommy";
    
    //Get idElement by username using Single()
    var idElement = xDoc.Descendants("id")
    				.Single(id => id.Attribute("username").Value == enteredUsername);
    
    //Get question and answer values from idElement
    var question = idElement.Attributes().Single(i => i.Name == "question").Value;
    var answer = idElement.Attributes().Single(i => i.Name == "answer").Value;
    Console.WriteLine(question);
    Console.WriteLine(answer);
