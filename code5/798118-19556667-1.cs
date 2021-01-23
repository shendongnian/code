    System.Windows.Forms.TableLayoutPanel PicrossGrid;
    List<PiCrossLabel> PicrossGridLabel;
    private void adjustGridLabel(int newSize)
    {
        for (int i = 0; i < newSize; i++)
        {
            for (int j = 0; j < newSize; j++)
            {
                    PiCrossLabel NewLabel = new PiCrossLabel();
                    NewLabel.Name = "PicrossGridLabelC" + (i + 1) + "R" + (j + 1);
                    TabIndex = (i * 5) + j;
                    PicrossGrid.Controls.Add(NewLabel, i, j);
            }
        }
        PicrossGridLabel = temp.ToList();
     }
    public class PiCrossLabel:Label
    {
        public PiCrossLabel()
        {
            this.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AutoSize = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(24, 30);
            this.Text = "X";
            this.TextAlign = System.Drawing.ContentAlignment.TopCenter;            
        }
    }
