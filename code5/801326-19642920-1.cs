        public Inicio()
        {
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;`
            InitializeComponent();//<<<<<<<<------------------- 
            this.ClientSize = new System.Drawing.Size(635, 332);
            this.StartPosition = FormStartPosition.CenterScreen;
            llenaForm(nombreFormulario);
            Application.EnableVisualStyles();
        }
