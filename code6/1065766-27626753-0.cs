    using (var input = File.OpenText("input.txt"))
    using (var output = new StreamWriter("output.txt")) {
      string line;
      while (null != (line = input.ReadLine()) {
         // Apply regex to line before writing to new outpu file
         output.WriteLine(line);
      }
    }
