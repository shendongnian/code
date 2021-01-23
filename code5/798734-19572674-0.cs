    // set path array
    var paths = new[] { sDrive, sFolder, sDivFolder };
    // use StringBuilder for faster string concatenation
    var sb = new StringBuilder();
    foreach (var p in paths)
    {
        // append next part of the path
        sb.Append(p);
        // check if it exists
        if (!Directory.Exists(sb.ToString()))
        {
            // print info message and return from method, because path is incorrect
            Console.WriteLine("FATAL: \"{0}\" path doesn't exist.", sb.ToString());
            return;
        }
    }
    // we are here, so the whole path works and we can set bSanity to true
    bSanity = true;
