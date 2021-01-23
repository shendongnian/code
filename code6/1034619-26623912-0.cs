            if (chkWebsite.Checked == true)
        {
            foreach (GridViewRow row in gVRecruiterView.Rows)
            {
                foreach (TableCell cell in row.Cells)
                {
                    string value = cell.Text.ToString();
                    if (System.Text.RegularExpressions.Regex.IsMatch(value, @"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$"))
                    {
                        cell.Text = "<a href='" + value + "'>" + value + "</a>";
                    }
                }
            }
        }
