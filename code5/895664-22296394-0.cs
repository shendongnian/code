    IEnumerator enum1 = lstRoles.GetEnumerator();
    IEnumerator enum2 = lstFunctions.GetEnumerator();
    int i = 1;
    while ((enum1.MoveNext()) && (enum2.MoveNext()))
    {
            selectListRoles.Add(new SelectListItem
            {
                Text = enum1.Current,
                Value = enum2.Current,
                Selected = (i == 0)
            });
            i++;
    }
