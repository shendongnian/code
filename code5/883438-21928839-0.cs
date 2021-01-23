    public static void FindControlsByTypeRecursive(Control root, Type type, ref List<Control> list)
    {
        if (root.Controls.Count > 0)
        {
            foreach (Control ctrl in root.Controls)
            {
                if (ctrl.GetType() == type) //if this control is the same type as the one specified
                    list.Add(ctrl); //add the control into the list
                else if (ctrl.HasControls()) //if this control has any children
                    FindControlsByTypeRecursive(ctrl, type, ref list); //search children
            }
        }
    }
