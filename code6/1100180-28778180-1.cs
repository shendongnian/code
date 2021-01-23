		var input = "<a href=\"/Forums2008/forumPage.aspx?forumId=317\" title=\"הנקה\">הנקה</a>";
		
		var expression = new System.Text.RegularExpressions.Regex(@"title=\""([^\""]+)\""");
		
		var match = expression.Match(input);
		
		if (match.Success) {
    		Console.WriteLine(match.Groups[1]);
  		}
		else {
  			Console.WriteLine("not found");
		}		
