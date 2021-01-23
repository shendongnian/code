    /// <summary> Unchecks all the radio buttons on each tab page except the active one </summary>
    /// <param name="activePage"> The active tab page when the radio button was clicked</param>
    private void UncheckLayouts(TabPage activePage)
    {
        foreach (TabPage tabPage in tabLayouts.TabPages)
        {
            if (tabPage == activePage) continue;
            foreach (RadioButton rb in tabPage.Controls)
            {
                rb.Checked = false;
            }
        }
    }
