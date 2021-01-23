    foreach (var item in Page.Controls)
        {
            if (item is TextBox)
            {
                ((TextBox)item).Text = "";
            }
            if (item is DropDownList)
            {
                ((DropDownList)item).SelectedIndex= 0;
            }
            //and the other types
        }
