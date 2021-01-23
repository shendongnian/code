     DirectoryInfo nodeDir = new DirectoryInfo(@"c:\files");
     Parallel.ForEach(nodeDir.GetDirectories(), async dir =>
     {
        foreach (string s in Directory.GetFiles(dir.FullName))
        {
           Invoke(new MethodInvoker(delegate { lbxParallel.Items.Add(s); }));
           contador++;
          await Task.Delay(1);
        }
     }
