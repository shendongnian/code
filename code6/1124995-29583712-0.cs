            jalons = new List<jalon>();
            jalon dr;
            for(int i =0; i<count;i++)
            {
                dr = new Jalon();
                dr.lab.Text = reader.GetValue(1).ToString();
                dr.lab.Location = new Point(j, j);
                dr.lab.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labMouseClick);
                dr.lab.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labMouseDown);
                dr.lab.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LabMouseMove);
                dr.lab.DoubleClick += new System.EventHandler(this.ChangColor);
                this.Controls.Add(dr.lab);
                this.Controls.Add(dr.line);
                
                jalons.Add(dr);
            }
