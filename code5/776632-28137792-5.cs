        public string FilePath
        {
            get { return filePath; }
            set
            {
                if (filePath == value)
                    return;
                filePath = value;
                NotifyOfPropertyChange(() => FilePath);
            }
        }
        /// <summary>
        /// Should wrap?
        /// </summary>
        public bool WordWrap
        {
            get { return wordWrap; }
            set
            {
                if (wordWrap == value)
                    return;
                wordWrap = value;
                NotifyOfPropertyChange(() => WordWrap);
            }
        }
        /// <summary>
        /// Display line numbers?
        /// </summary>
        public bool ShowLineNumbers
        {
            get { return showLineNumbers; }
            set
            {
                if (showLineNumbers == value)
                    return;
                showLineNumbers = value;
                NotifyOfPropertyChange(() => ShowLineNumbers);
            }
        }
        /// <summary>
        /// Hold the start of the currently selected text.
        /// </summary>
        private int selectionStart = 0;
        public int SelectionStart
        {
            get { return selectionStart; }
            set
            {
                selectionStart = value;
                NotifyOfPropertyChange(() => SelectionStart);
            }
        }
        /// <summary>
        /// Hold the selection length of the currently selected text.
        /// </summary>
        private int selectionLength = 0;
        public int SelectionLength
        {
            get { return selectionLength; }
            set
            {
                selectionLength = value;
                UpdateStatusBar();
                NotifyOfPropertyChange(() => SelectionLength);
            }
        }
        /// <summary>
        /// Gets or sets the TextLocation of the current editor control. If the 
        /// user is setting this value it will scroll the TextLocation into view.
        /// </summary>
        private TextLocation textLocation = new TextLocation(0, 0);
        public TextLocation TextLocation
        {
            get { return textLocation; }
            set
            {
                textLocation = value;
                UpdateStatusBar();
                NotifyOfPropertyChange(() => TextLocation);
            }
        }
        
