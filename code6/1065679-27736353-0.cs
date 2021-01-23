    readonly string _folderMyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    private int _lineCount;
    public void RunWatcher()
        {
            var watcher = new FileSystemWatcher(_folderMyDocuments + @"\Entropia Universe\", "chat.log");
            watcher.NotifyFilter = NotifyFilters.Size;
            watcher.Changed += OnChanged;
            watcher.EnableRaisingEvents = true;
        }
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            var regex =
                new Regex(
                    @"^(?<Date>\d{4}-\d{2}-\d{2})\s(?<Time>\d{2}\:\d{2}\:\d{2})\s(?:\[(?:Team|Force)\]\s\[\]\s)(?<User>.+)(?:\sreceived\s)(?<Item>[^\(]+)(?:(?:\s\((?:(?<Amount>\d+|\w+)).+$)|\.$)$",
                    RegexOptions.Compiled);
            using (var sr = new StreamReader(_folderMyDocuments + @"\Entropia Universe\chat.log"))
            {
                for (var i = 0; i < _lineCount; i++)
                {
                    sr.ReadLine();
                }
                while (!sr.EndOfStream)
                {
                    var newLines = sr.ReadLine();
                    if (newLines != null)
                    {
                        _lineCount++;
                        foreach (Match match in regex.Matches(newLines))
                        {
                            Dispatcher.Invoke(() =>
                            {
                                RTB1.AppendText(
                                    match.Groups["Date"] + " " +
                                    match.Groups["Time"] + " " +
                                    match.Groups["User"] + " " +
                                    match.Groups["Item"] + " " +
                                    match.Groups["Amount"] + "\r"
                                    );
                            });
                        }
                    }
                    
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BTN_Start.IsEnabled = false;
            using (var r = new StreamReader(_folderMyDocuments + @"\Entropia Universe\chat.log"))
            {
                while ((r.ReadLine()) != null)
                {
                    _lineCount++;
                }
            }
            RunWatcher();
        }
