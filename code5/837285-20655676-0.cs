    var original = XDocument.Parse(/* your XML as string */);
    var normalized = new XDocument(original);
    foreach (var phraseNode in normalized.Root.Elements("phrase"))
    {
       phraseNode.Elements().Remove();
       int ansNo = 1;
       
       foreach(var answer in original.Root
                                     .Elements("phrase")
    								 .Single(p => p.Attribute("permutation").Value
    								            == phraseNode.Attribute("permutation").Value)
    							     .Elements("ans"))
       {
          var groupedWords = answer.Elements("word")
    							   .GroupBy(w => w.Attribute("set").Value)
    			                   .ToArray();
          var newAnswers = groupedWords.Skip(1)
    	                               .Aggregate(
    								     groupedWords[0].Select(w => Enumerable.Repeat(w, 1)),
    				                     (combinations, newWords) =>
    							             combinations.Join(newWords,
    								                           c => 1,
    												           w => 1,
    												           (c, w) => c.Concat(new[] { w })));
    	  foreach (var newAnswer in newAnswers)
    	  {
    	     var ansNode = new XElement("ans", new XAttribute("number", ansNo++));
    		 ansNode.Add(newAnswer.Select(w => new XElement(w)).ToArray());
    		 phraseNode.Add(ansNode);
    	  }
       }
    }
