    void hide(Control el, string cssClass) {
        foreach (WebControl c in el.Controls)
        {
            if (c.CssClass == cssClass)
            {
                c.Visible = false;
            }
        }
    }
