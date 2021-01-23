    public partial class UserControl1 : UserControl
    {
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.TextBox textBox1;
      public UserControl1()
      {
         InitializeComponent();
         this.panel1 = new System.Windows.Forms.Panel();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.panel1.Controls.Add(this.textBox1);
         this.panel1.Location = new System.Drawing.Point(3, 14);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(200, 100);
         this.panel1.TabIndex = 0;
         this.textBox1.Location = new System.Drawing.Point(33, 15);
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(100, 20);
         this.textBox1.TabIndex = 0;
         this.Controls.Add(this.panel1);
         textBox1.ForeColor = panel1.ForeColor;
      }
      public Color ForeColor
      {
         get
         {
            return textBox1.ForeColor;
         }
         set
         {
            panel1.ForeColor = value;
            textBox1.ForeColor = value;
         }
      }
    }
