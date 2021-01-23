    public Mainform()
    {
            
     InitializeComponent();
     this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
    
     // Close
     // 
     this.CloseBut.BackColor = System.Drawing.Color.Black;
     this.CloseBut.FlatAppearance.BorderColor = System.Drawing.Color.White;
     this.CloseBut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
     this.CloseBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
     this.CloseBut.ForeColor = System.Drawing.SystemColors.ButtonFace;
     //this.CloseBut.Location = new System.Drawing.Point(376, 0);
     this.CloseBut.Name = "Close";
     this.CloseBut.Size = new System.Drawing.Size(27, 23);
     this.CloseBut.TabIndex = 1;
     this.CloseBut.Text = "X";
     this.CloseBut.UseVisualStyleBackColor = false;
     this.CloseBut.Click += new System.EventHandler(this.Close_Click);
     // 
     // Hide
     // 
     this.HideBut.BackColor = System.Drawing.SystemColors.ControlText;
     this.HideBut.FlatAppearance.BorderColor = System.Drawing.Color.White;
     this.HideBut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
     this.HideBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
     this.HideBut.ForeColor = System.Drawing.SystemColors.ButtonFace;
     //this.HideBut.Location = new System.Drawing.Point(346, 0);
     this.HideBut.Name = "Hide";
     this.HideBut.Size = new System.Drawing.Size(30, 23);
     this.HideBut.TabIndex = 0;
     this.HideBut.Text = "---";
     this.HideBut.UseVisualStyleBackColor = true;
     this.HideBut.Click += new EventHandler(this.hide_click);
    }
    private void hide_click(object sender, EventArgs e)
    {
        this.WindowState=FormWindowState.Minimized;
    }
    private void Close_Click(object sender, EventArgs e)
    {
        this.Close();
    }
