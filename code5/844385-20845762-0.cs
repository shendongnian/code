    string expr = @"Content=""[^""]*""";
    System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(expr);
    string data = @"<SomeControl Content=""sup""><anotherControl Content=""hey""><athird Content=""yo""></athird></anotherControl></SomeControl>"; // This will be replaced with actual file content
    var res = reg.Matches(data);
    var occuranceCount = res.Count;
