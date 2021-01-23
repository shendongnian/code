    private void tabControl1_Deselecting(object sender, TabControlCancelEventArgs e)
    {
        switch (e.TabPageIndex)
        {
            case 0: 
                if (!validateTab1())
                {
                    e.Cancel = true;
                }
                break;
            case 1: 
                if (!validateTab2())
                {
                    e.Cancel = true;
                }
                break;
            default:
                break;
        }
    }
