    public static Process Start(ProcessStartInfo startInfo)
    {
         Process process = new Process();
         if (startInfo == null) throw new ArgumentNullException("startInfo");
         process.StartInfo = startInfo;
         if (process.Start()) {
             return process;
         }
         return null;
    }
