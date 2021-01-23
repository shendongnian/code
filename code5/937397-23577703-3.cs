    Process p = new Process();
    p.StartInfo.FileName = path;
    p.Start();
    /* Wait for process to exit. WARNING: This will block the UI if executed in the main thread... */
    while (!p.HasExited) {
        System.Threading.Thread.Sleep(200); // Wait 200ms before testing p.HasExited again.
    }
    /* Process exited */
    p.StartInfo.FileName = newpath;
    p.Start();
