    for (int i = 0; i < 10; i++)
    {
      int currentLevel = 0;
      var regex = new System.Text.RegularExpressions.Regex(@"\((?<number>\d+)\)$");
      
      var m = regex.Match(inputText);
      string strLeft = inputText + " (", strRight = ")";
      if (m.Success)
      {
        var levelText = m.Groups["number"];
        if (int.TryParse(levelText.Value, out currentLevel))
        {
          var numCap = levelText.Captures[0];
          
          strLeft = inputText.Substring(0, numCap.Index);
          strRight = inputText.Substring(numCap.Index + numCap.Length);
        }
      }
          
      inputText = strLeft + (++currentLevel).ToString() + strRight;
      
      output.AppendLine(inputText);
    }
