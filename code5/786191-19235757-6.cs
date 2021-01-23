    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        // Move your Cat here
        switch (keyData)
        {
            case Keys.Left:
                cat.Move(keyData);
                break;
            case Keys.Right:
                break;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }
    public class Cat
    {
        public void Move(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    // act accordingly ...
                    break;
                case Keys.Right:
                    break;
            }
        }
    }
