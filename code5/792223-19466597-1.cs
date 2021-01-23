        StringBuilder message = new StringBuilder();
        string relativeUri = string.Empty;
        message.AppendFormat("Received Toast {0}:\n", DateTime.Now.ToShortTimeString());
        // Parse out the information that was part of the message.
        foreach (string key in e.Collection.Keys)
        {
            message.AppendFormat("{0}: {1}\n", key, e.Collection[key]);
            if (string.Compare(
                key,
                "wp:Param",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.CompareOptions.IgnoreCase) == 0)
            {
                relativeUri = e.Collection[key];
            }
        }
        // Display a dialog of all the fields in the toast.
        MessageBox.Show(message.ToString());
        //Dispatcher.BeginInvoke((message) => MessageBox.Show(message.ToString()));
    }
