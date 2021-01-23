    using System;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public class ExampleForm : Form
        {
            private System.Windows.Forms.MenuStrip menuStrip1;
            private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
            public ExampleForm()
            {
                InitializeComponent();
            }
            private void InitializeComponent()
            {
                this.menuStrip1 = new System.Windows.Forms.MenuStrip();
                this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                this.menuStrip1.SuspendLayout();
                this.SuspendLayout();
                // 
                // menuStrip1
                // 
                this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.fileToolStripMenuItem});
                this.menuStrip1.Location = new System.Drawing.Point(0, 0);
                this.menuStrip1.Name = "menuStrip1";
                this.menuStrip1.Size = new System.Drawing.Size(1002, 24);
                this.menuStrip1.TabIndex = 1;
                this.menuStrip1.Text = "menuStrip1";
                this.menuStrip1.ItemAdded += new System.Windows.Forms.ToolStripItemEventHandler(this.menuStrip1_ItemAdded);
                // 
                // fileToolStripMenuItem
                // 
                this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.openToolStripMenuItem});
                this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
                this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
                this.fileToolStripMenuItem.Text = "&File";
                // 
                // openToolStripMenuItem
                // 
                this.openToolStripMenuItem.Name = "openToolStripMenuItem";
                this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
                this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
                this.openToolStripMenuItem.Text = "&Open";
                this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(1002, 674);
                this.Controls.Add(this.menuStrip1);
                this.IsMdiContainer = true;
                this.MainMenuStrip = this.menuStrip1;
                this.Name = "Form1";
                this.Text = "Form1";
                this.menuStrip1.ResumeLayout(false);
                this.menuStrip1.PerformLayout();
                this.ResumeLayout(false);
                this.PerformLayout();
            }
            private void openToolStripMenuItem_Click(object sender, EventArgs e)
            {
                var form = new Form
                {
                    Text = "Child",
                    MdiParent = this,
                    ShowIcon = false
                };
                form.Show();
            }
            private void menuStrip1_ItemAdded(object sender, ToolStripItemEventArgs e)
            {
                if (e != null && e.Item != null && e.Item.GetType().Name == "SystemMenuItem")
                {
                    this.menuStrip1.Items.RemoveAt(0);
                }
            }
        }
    }
