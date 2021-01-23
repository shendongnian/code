        //-->EDITED
        private void OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Notification t = (Notification)e.UserState;
            Notification toAdd = new Notification(t.Parent, t.OriginalSource, t.Headline, t.Note, t._originalImageSource);
            this.NotificationItems.Add(toAdd);
            if (this.NotificationItems.Count > 0 && this.NotificationPanel.Width.Value == 0)
                this.NotificationPanel.Width = new GridLength(NOTIFICATION_BAR_WIDTH);
        }
        //<--EDITED
