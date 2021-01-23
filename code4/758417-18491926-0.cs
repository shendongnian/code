    using (TextWriter tw = new StreamWriter(path))
    {
         StringBuilder sb = new StringBuilder();
         sb.Append("Manual Numbers=");
         sb.Append(Environment.NewLine);
         sb.Append("Installation Technical Manual: ");
         sb.Append("Performance Manual: ");
         sb.Append("Planned Maintenance Technical Manual: ");
         sb.Append("Service Calibration Manual: ");
         sb.Append("System Information Manual: ");
         sb.Append(Environment.NewLine);
         tw.Write(sb.ToString());
     }
