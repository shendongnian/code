    /// <summary>
            /// Delegate for setting text box text
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public delegate void TextBoxEventHandler(object sender, TextEventArgs e);
            /// <summary>
            /// Event for changing tool bar text
            /// </summary>
            public event TextBoxEventHandler ChangeTextBoxText = delegate { };
            /// <summary>
            /// Function that raises set tool bar text event
            /// </summary>
            /// <param name="s"></param>
            public void SetTextBoxText(string s)
            {
                ChangeTextBoxText(this, new TextEventArgs(s));
            }
