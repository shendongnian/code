    Guide.BeginShowMessageBox("Version of Windows", "Pick a version of Windows.",
        new List<string> { "Vista", "Seven" }, 0, MessageBoxIcon.Error, 
        asyncResult => 
        {
            int? returned = Guide.EndShowMessageBox(asyncResult);
            Debug.WriteLine(returned.ToString());
        }, null);
