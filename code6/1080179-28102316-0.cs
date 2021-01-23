    int j=0;
    foreach (var item in panel1.Controls)
            {
                if (item is Button)
                {
                    var tmp = (Button)panel1.Controls[i];
                    tmp.Text = j.ToString();
                    j++;
                }
                i++;
            }
