    string tst;
    int i,j, stat =0;
    tst = textBox1.Text;
    for (i = 0; i < tst.Length; i++)
    {
        for (j = 0; j < tst.Length; j++)
        {
            if (tst[i] == tst[j])
            {
                stat = 1;
                break;
            }
            else continue;
        }
        if (stat == 1) break;
        else continue;
    }
    if (stat == 1) MessageBox.Show("False");
    else MessageBox.Show("True");
