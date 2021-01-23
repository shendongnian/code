    public static Control FindControlRecursive(Control ctl, string id) {
        if (!ctl.HasControls())
            return null;
        Control res = null;
        foreach(Control c in ctl.Controls) {
            if (c.ID == id) {
                res = c;
                break;
            } else {
                res = FindControlRecursive(c, id);
                if (res != null)
                    break;
            }
        }
        return res;
    }
