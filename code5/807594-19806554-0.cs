    var sqlProcess = new ProcessStartInfo();
    sqlProcess.FileName = "SQLCMD.EXE";
    sqlProcess.Arguments = String.Format("-S {0} -U {2} -P {3}",
                                        server,
                                        user,
                                        password);
    Process.Start(sqlProcess);
