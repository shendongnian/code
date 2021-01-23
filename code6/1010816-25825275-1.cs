    Control page = null;
    switch (pageNumber) {
        case 1:
            page = new UserControl1();
            break;
        case 2:
            page = new UserControl2();
            break;
    }
    page.Dock = DockStyle.Fill;
    if (previousPage != null) {
        frm.Controls.Remove(previousPage);
    }
    frm.Controls.Add(page);
    previousPage = page;
