        bool changesDetected = false;
        public void Setup()
        {
            ListView view = new ListView();
            view.AfterLabelEdit += WatchOutForChanges;
            view.ControlAdded += WatchOutForChanges;
            view.ControlRemoved += WatchOutForChanges;
        }
        public void WatchOutForChanges(object sender, EventArgs e)
        {
            changesDetected = true;
        }
