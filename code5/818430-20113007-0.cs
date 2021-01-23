     PictureBox[] Shapes = new PictureBox[Num_Picbox];
        
                            for (int i = 0; i < Num_Picbox; i++)
        
                            {
        
                                Shapes[i] = new PictureBox();
        
                                Shapes[i].Name = "ItemNum_" + i.ToString();
        
                                Shapes[i].Location = new Point(label5.Left+1,label5.Top);
        
                                Shapes[i].Size = new Size(100, 100);
        
                                Shapes[i].BackColor = Color.Black;
        
                                Shapes[i].Image = (Bitmap)(e.Data.GetData(DataFormats.Bitmap));
        
                                Shapes[i].Visible = true;
        
                                this.Controls.Add(Shapes[i]);
        
                            }
