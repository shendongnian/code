       PictureBox[] pics = new PictureBox[50];
        TextBox[] txts = new TextBox[50];
        Button[] butns = new Button[50];
        FlowLayoutPanel[] flws = new FlowLayoutPanel[50]
        static int brh =0; 
        for (int i = 0; i < totalnumbers; i++)
            {
                flws[i] = new FlowLayoutPanel();
                flws[i].Name = "flw" + i;
                flws[i].Location = new Point(3,brh);
                flws[i].Size = new Size(317,122);
                flws[i].BackColor = Color.DarkCyan;
                flws[i].BorderStyle = BorderStyle.Fixed3D;
                flws[i].Disposed += Form1_Disposed;               
                flws[i].Click += new EventHandler(butns_Click);
                pics[i] = new PictureBox();
                pics[i].Location = new Point(953, 95 + brh);
                pics[i].Name = "pic" + i;
                pics[i].Size = new Size(300, 75);
                pics[i].ImageLocation = "E:/image"+i;
                flws[i].Controls.Add(pics[i]);
                
                txts[i] = new TextBox();
                txts[i].Name = "txt" + i;
                txts[i].Location = new Point(953, 186 + brh);
                txts[i].TextChanged += Form1_TextChanged;
                flws[i].Controls.Add(txts[i]);
                butns[i] = new Button();
                butns[i].Click += new EventHandler(butns_Click);
                butns[i].Text = "submit";
                butns[i].Name = "but" + i;
                butns[i].Location = new Point(1100, 186 + brh);
                
                flws[i].Controls.Add(butns[i]);
                this.Controls.Add(flws[i]);
                flowLayoutPanel1.Controls.Add(flws[i]);
                brh += 130;
            }  
     private void butns_Click(object sender, EventArgs e)
        {
            // you can add the procces to perform after dynamically created button pressed
         }
