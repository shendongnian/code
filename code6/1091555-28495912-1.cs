        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Right:
                case Keys.Right|Keys.Shift:
                case Keys.Enter:
                    // move to next field
                    this.NextField();
                    return true;
                case Keys.Left:
                case Keys.Left|Keys.Shift:
                    // move to previous field
                    this.PreviousField();
                    return true;
                case Keys.Down:
                case Keys.Down|Keys.Shift:
                case Keys.Up:
                case Keys.Up|Keys.Shift:
                    // disable native navigation
                    return true;
                case Keys.Tab:
                    // move to next point
                    return this.NextPoint();
                case Keys.Tab|Keys.Shift:
                    // move to previous point
                    return this.PreviousPoint();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
