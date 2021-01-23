            private void YourControl_KeyDown(object sender, KeyEventArgs e)
            {
                //your logic here
            }
    
            protected override bool IsInputKey(System.Windows.Forms.Keys keyData)
            {
                switch (keyData)
                {
                    case Keys.Right:
                    case Keys.Left:
                    case Keys.Up:
                    case Keys.Down:
                        return true;
                }
                return base.IsInputKey(keyData);
            }
