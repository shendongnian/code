        // MainWindow...
        Task t; // keep for cleanup
        // Update on the UI thread
        private void SetMyValueAsync(string value)
        {
            Application.Current.Dispatcher.BeginInvoke((Action)(() => MyValue = value));
        }
        private void ScriptToFileButton_Click(object sender, RoutedEventArgs e)
        {
            t = Task.Factory.StartNew(() =>
            {
                SetMyValueAsync("Scripting, please wait..");
                // If the following lines will update the UI
                // they should do so on the UI thread per Dr. Xu's post.
                // String text = DBObjectsTextArea.Text;
                // String[] args = text.Split(' ');
                // SQLScripter scripter = new SQLScripter();
                //scripter.script(args);
                for (int i = 0; i < 50; i++)
                {
                    System.Threading.Thread.Sleep(100);
                    SetMyValueAsync(i.ToString());
                }
                SetMyValueAsync("Done!");
            });
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (t != null)
            {
                try { t.Dispose(); }
                catch (System.InvalidOperationException)
                {
                    e.Cancel = true;
                    MessageBox.Show("Cannot close. Task is not complete.");
                }
            }
            base.OnClosing(e);
        }
