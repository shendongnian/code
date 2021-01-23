     RichTextBox.Loaded += delegate
            {
                Dispatcher.BeginInvoke(
                    DispatcherPriority.Normal,
                    new Action(
                        delegate()
                        {
                            Keyboard.Focus(RichTextBox);
                            RichTextBox.Selection.Select(
                                RichTextBox.Document.ContentStart,
                                RichTextBox.Document.ContentEnd);
                        }));
            };
