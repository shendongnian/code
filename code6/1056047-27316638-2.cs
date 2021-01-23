    public static bool WriteResult(string result)
            {
                using (StreamWriter sr = File.AppendText("result.txt"))
                {
                    sr.WriteLine(result);
                    sr.Flush();
                    return true;
                }
                return false;
            }
