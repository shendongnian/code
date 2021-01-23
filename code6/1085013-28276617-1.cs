    Dictionary<string, string> _log = new Dictionary<string, string>();
    void UpdateTextBox(string id)
    {
        if (textBox1.InvokeRequired)
            Invoke(UpdateTextBox, new object[] { id });
        else
            textBox1.Text = _log[id];
    }
    void AddToLog(string id, string message)
    {
        // add new or update
        if(_log.ContainsKey(id))
            _log[id] = string.Format("{0}{1} {2}{3}", Environment.NewLine, DateTime.Now, message, _log[id]);
        else
            _log.Add(id, string.Format("{0}{1} {2}", Environment.NewLine, DateTime.Now, message);
        UpdateTextBox(id);
    }
