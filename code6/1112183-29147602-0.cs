    rc = Convert.ToInt16(textBox1.Text);
    if (rc == 3 || rc == 5 || rc == 7 || rc == 9 || rc == 11)
    {
        centro = rc / 2;
        centro1 = Math.Round(centro, 0);
        int[,] dim = new int[rc, rc];
        int v = 1, r = 0, c, x = 0;
        c = Convert.ToInt16(centro1);
        //rc2 = rc;
        for (x = 0; x < (rc*rc); x++)
        {
            if (dim[r, c] >= 1)
            {
                r = r2 + 2;
                c = c2 - 1;
                dim[r, c] = v;
            }
            else
            {
                dim[r, c] = v;
            }
            c++;
            r--;
            v++;
            if (r < 0)
            {
                r = rc -1;
            };
            if (c > (rc-1))
            {
                c = 0;
            };
            r2 = r;
            c2 = c;                      
        } 
        else {
            textBox1.Text = "";
            MessageBox.Show("***Error***   blah blah blah");
        }
