    Process p = new Process();
    p.StartInfo.FileName = path;
    p.Start();
    /* Wait for process to exit */
    while (!p.HasExited) {
        System.Threading.Thread.Sleep(200); // Wait 200ms before testing p.HasExited again.
    }
    /* Process exited */
    p.StartInfo.FileName = newpath;
    p.Start();
