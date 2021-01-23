    var sqlProcess = new ProcessStartInfo();
    sqlProcess.FileName = "SQLCMD.EXE";
    sqlProcess.Arguments = String.Format("-S {0} -U {1} -P {2}",
                                        server,
                                        user,
                                        password);
    Process.Start(sqlProcess);
