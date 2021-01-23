        internal sealed class DataGridViewTextButtonColumn : DataGridViewColumn
        {
            private EventHandler<TextButton.TextButtonEventArgs> buttonClickHandler;
            public DataGridViewTextButtonColumn()
                : base(new DataGridViewTextButtonCell())
            {
            }
            public EventHandler<TextButton.TextButtonEventArgs> ButtonClickHandler
            {
                get
                {
                    return buttonClickHandler;
                }
                set
                {
                    DataGridViewTextButtonCell cell = CellTemplate as DataGridViewTextButtonCell;
                    if (cell != null)
                    {
                        if (value != null)
                            cell.ButtonClickHandler += value;
                        else if (buttonClickHandler != null)
                            cell.ButtonClickHandler -= buttonClickHandler;
                    }
                    buttonClickHandler = value;
                }
            }
            public override DataGridViewCell CellTemplate
            {
                get
                {
                    return base.CellTemplate;
                }
                set
                {
                    base.CellTemplate = value;
                    DataGridViewTextButtonCell cell = CellTemplate as DataGridViewTextButtonCell;
                    if (cell != null)
                        cell.ButtonClickHandler = ButtonClickHandler;
                }
            }
        }
