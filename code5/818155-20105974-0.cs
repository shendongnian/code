            Panel pnl;
            Label lbl;
            PictureBox pb;
            Control[] matches;
            for(int i = 1; i <= 40; i = i + 3)
            {
                matches = this.Controls.Find("panel" + i.ToString(), true);
                if (matches.Length > 0 && matches[0] is Panel)
                {
                    pnl = matches[0] as Panel;
                    matches = this.Controls.Find("label" + (i + 1).ToString(), true);
                    if (matches.Length > 0 && matches[0] is Label)
                    {
                        lbl = matches[0] as Label;
                        matches = this.Controls.Find("pictureBox" + (i + 2).ToString(), true);
                        if (matches.Length > 0 && matches[0] is PictureBox)
                        {
                            pb = matches[0] as PictureBox;
                            myFunction(pnl, lbl, pb);
                        }
                    }
                }
            }
