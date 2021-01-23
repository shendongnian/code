    private Task<string> ImportXML()
    {
        ParseXML.ParseXML parsexml = new ParseXML.ParseXML(chosenFile);
        ProgressDialog progress = new ProgressDialog(this);
        progress.SetMessage(GetString(Resource.String.ImportXML));
        progress.Indeterminate = true;
        progress.Show();
        var task = Task.Factory.StartNew(() => parsexml.ProcessXML());
        task.ContinueWith(t => progress.Hide());
        return task;
    }
