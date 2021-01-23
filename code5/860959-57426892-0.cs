    catch (Exception e)
    {
        new MessageWriteToFile(e).WriteToFile();
    }
    public class MessageWriteToFile
    {
        private const string Directory = "C:\\AppLogs";
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public string DefaultPath
        {
            get
            {
                var appName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                var folder = $"{Directory}\\{appName}";
                if (!System.IO.Directory.Exists(folder))
                {
                    System.IO.Directory.CreateDirectory(folder);
                }
                var fileName = $"{DateTime.Today:yyyy-MM-dd}.txt";
                return $"{Directory}\\{appName}\\{fileName}";
            }
        }
        public MessageWriteToFile(string message)
        {
            Message = message;
        }
        public MessageWriteToFile(Exception ex)
        {
            Exception = ex;
        }
        public bool WriteToFile(string path = "")
        {
            if (string.IsNullOrEmpty(path))
            {
                path = DefaultPath;
            }
             try
            {
                using (var writer = new StreamWriter(path, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Date : " + DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine();
                    if (Exception != null)
                    {
                        writer.WriteLine(Exception.GetType().FullName);
                        writer.WriteLine("Source : " + Exception.Source);
                        writer.WriteLine("Message : " + Exception.Message);
                        writer.WriteLine("StackTrace : " + Exception.StackTrace);
                        writer.WriteLine("InnerException : " + Exception.InnerException?.Message);
                    }
                    if (!string.IsNullOrEmpty(Message))
                    {
                        writer.WriteLine(Message);
                    }
                    writer.Close();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
