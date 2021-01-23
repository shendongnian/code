    public static bool WriteResult(string result)
            {
                using (StreamWriter sr = File.AppendText("result.txt"))//new StreamWriter("result.txt", Encoding. ))
                {
    
                    sr.WriteLine(result);
                    sr.Flush();
                    return true;
                }
    
                return false;
    
            }
