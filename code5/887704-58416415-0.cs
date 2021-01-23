private void cboNumberOfPanels_SelectedIndexChanged(object sender, EventArgs e)
{
    int numberOfPanels;
    int.TryParse(cboNumberOfPanels.SelectedItem.ToString(), out numberOfPanels);
    pnlPanelDimensions1.Visible = numberOfPanels >= 1;
    pnlPanelDimensions2.Visible = numberOfPanels >= 2;
    pnlPanelDimensions3.Visible = numberOfPanels >= 3;
    pnlPanelDimensions4.Visible = numberOfPanels >= 4;
    pnlPanelDimensions5.Visible = numberOfPanels >= 5;
}
I tried using the .SetChildIndex() suggestion above, but still ran into issues on the second selection.  For example, if I selected 1, pnlPanelDimensions1 would display in the correct position.  If then chose 3, I would get pnlPanelDimensions2 displayed first, followed by pnlPanelDimensions3, and finally pnlPanelDimensions1.  On all subsequent changes after the second, everything would display correctly.
I did finally find an option that worked correctly every time in my solution:
    int numberOfPanels;
    int.TryParse(cboNumberOfPanels.SelectedItem.ToString(), out numberOfPanels);
    pnlPanelDimensions1.Visible = numberOfPanels >= 1;
    pnlPanelDimensions1.BringToFront();
    pnlPanelDimensions2.Visible = numberOfPanels >= 2;
    pnlPanelDimensions2.BringToFront();
    pnlPanelDimensions3.Visible = numberOfPanels >= 3;
    pnlPanelDimensions3.BringToFront();
    pnlPanelDimensions4.Visible = numberOfPanels >= 4;
    pnlPanelDimensions4.BringToFront();
    pnlPanelDimensions5.Visible = numberOfPanels >= 5;
    pnlPanelDimensions5.BringToFront();
