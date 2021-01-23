    string file1 = "firstFile.txt";
      // Placing htese resources in using blocks ensures that their resources are released when you are done
      // with them.
      using (Stream fs = new FileStream(file1, FileMode.Append))
      using (TextWriter tx1 = new StreamWriter(fs))
      {
        // This will only keep track of the file information when you call it.
        // Any subsequent changes to the file will not update this variable.
        FileInfo fi1 = new FileInfo(file1);
        if (fi1.Length < 1024)
        {
          tx1.WriteLine("Babloooooooooooooooooo ");
          // If you don't flush this line, you won't get an up to date value for 'length' below.
          // Comment it out, and see for yourself.
          tx1.Flush();
          Console.WriteLine("The length is...", fs.Length);
        }
        else
        {
          Console.WriteLine("Limit reached");
        }
      }
