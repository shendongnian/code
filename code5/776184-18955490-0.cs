      // Read the stuff from the file, gets an string[]
      var lines = File.ReadAllLines(@"file.txt");
      foreach (var line in lines)
      {
          var splitLine = line.Split(' ');
          var score = double.Parse(splitLine.Last(), CultureInfo.InvariantCulture);
          
          // The math wizard is in town!
          score = score + 3;
          // Put it back
          splitLine[splitLine.Count() - 1] = score.ToString();
      
          // newLine is the new line, what should we do with it?
          var newLine = string.Join(" ", splitLine);
          // Lets print it cause we are out of ideas!
          Console.WriteLine(newLine);
      }
