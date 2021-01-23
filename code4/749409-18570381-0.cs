           Form f = Application.OpenForms["Form1"];
            for (int df = 0; df < tblmodelform2.Rows.Count; df++)
            {
                
                    int sNumber = ((Form1)f).tabmodelform1.Rows.Count;
                    Row r = new Row();
                    //int ss = int.Parse(s);
                    r.Cells.Add(new Cell(sNumber, Color.DarkBlue, Color.FromArgb(234, 215, 184), f2));
                    r.Cells.Add(new Cell(tblProxies22[df,1].Text, Color.FromArgb(225, 175, 91), Color.White, f2));
                    // r.Cells.Add(new Cell(pa, Color.FromArgb(225, 175, 91), Color.White, f2));
                    r.Cells.Add(new Cell("", (Image)new Bitmap(10, 10), Color.YellowGreen, Color.White, f2));
                    r.Cells.Add(new Cell("", (Image)new Bitmap(10, 10), Color.YellowGreen, Color.White, f2));
                    r.Cells.Add(new Cell("", (Image)new Bitmap(10, 10)));
                    //   r.Cells.Add(new Cell("", (Image)new Bitmap(10, 10)));
                    if (!IsHandleCreated)
                    {
                        this.CreateControl();
                        ((Form1)f).tabmodelform1.Rows.Add(r);
                    }
                    else
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            ((Form1)f).tabmodelform1.Rows.Add(r);
                        }));
                    }
                
            }
