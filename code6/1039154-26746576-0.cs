        static TimeSpan? ExtractTime(string logLine)
        {
            var tokens = logLine.Split(new char [] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length < 2)
                return null;
            TimeSpan time;
            if (!TimeSpan.TryParse(tokens[1], out time))
                return null;
            return time;
        }
        static IEnumerable<string> EnumerateLines(StreamReader sReader)
        {
            string line;
            while ((line = sReader.ReadLine()) != null)
                yield return line;
        }
        static void OutputLogLinesBeforeTime(IEnumerable<string> lines, TimeSpan time)
        {
            foreach (var line in lines.Where(l => ExtractTime(l) < time))
                Debug.WriteLine(line);
        }
        static void OutputLogLinesBeforeTime(string strLogDirectory, string strLogDate, string strCallTime)
        {
            try
            {
                var time = TimeSpan.Parse(strCallTime);  // Throws a format exception if invalid.
                DirectoryInfo d = new DirectoryInfo(strLogDirectory + "\\" + strLogDate + "\\");
                foreach (var file in d.GetFiles("*.ininlog_journal"))
                {
                    try
                    {
                        using (Stream stream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        using (StreamReader sReader = new StreamReader(stream))
                        {
                            OutputLogLinesBeforeTime(EnumerateLines(sReader), time);
                        }
                    }
                    catch (UnauthorizedAccessException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                    catch (SystemException se)
                    {
                        Console.WriteLine(se.Message);
                    }
                    catch (ApplicationException ape)
                    {
                        Console.WriteLine(ape.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            catch (UnauthorizedAccessException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (SystemException se)
            {
                Console.WriteLine(se.Message);
            }
            catch (ApplicationException ape)
            {
                Console.WriteLine(ape.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
