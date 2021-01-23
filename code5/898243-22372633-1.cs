    using (StreamReader reader = process.StandardError) {
      string result = reader.ReadToEnd();
      System.Diagnostics.Debug.Write(result);
    }
    
    using (StreamReader reader = process.StandardOutput) {
      string result = reader.ReadToEnd();
      System.Diagnostics.Debug.Write(result);
    }
    process.WaitForExit();
