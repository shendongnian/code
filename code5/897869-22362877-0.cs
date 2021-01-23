    public static void ShowCentered(this Form frm, Form owner)
    {
        Rectangle ownerRect = GetOwnerRect(frm, owner);
        frm.Location = new Point(ownerRect.Left + (ownerRect.Width - frm.Width) / 2,
                                 ownerRect.Top + (ownerRect.Height - frm.Height) / 2);
        frm.Show(owner);
    }
    public static void ShowDialogCentered(this Form frm, Form owner)
    {
        Rectangle ownerRect = GetOwnerRect(frm, owner);
        frm.Location = new Point(ownerRect.Left + (ownerRect.Width - frm.Width) / 2,
                                 ownerRect.Top + (ownerRect.Height - frm.Height) / 2);
        frm.ShowDialog(owner);
    }
    private static Rectangle GetOwnerRect(Form frm, Form owner)
    {
        return owner != null ? owner.DesktopBounds : Screen.GetWorkingArea(frm);
    }
