    public partial class MFDesigner : Form {
        private ToolStripPanel tsPanel;
        //private Panel pnlToolbox;
        //private Panel pnlProperties;        
    
        public MFDesigner ( )
        {
          InitializeComponent();
          //
          // first toolstrip
          //
          ToolStripButton tsbOpen = new ToolStripButton("Open", null, new EventHandler(this.OnOpen), "Open saved file");
          ToolStripButton tsbSave = new ToolStripButton("Save", null, new EventHandler(this.OnSaveToDisk), "Save to disk");
          ToolStripButton[] openSaveButtonArr = new ToolStripButton[] { tsbOpen, tsbSave };
          ToolStrip openSaveToolStrip = new ToolStrip(openSaveButtonArr) { CanOverflow = true };
          this.tsPanel.Join(openSaveToolStrip);    
          //
          // second toolstrip
          //
          ToolStripButton tsbOpen2 = createToolStripButton("Open2", null, new EventHandler(this.OnOpen), "Open saved file");
          ToolStripButton tsbSave2 = createToolStripButton("Save2", null, new EventHandler(this.OnSaveToDisk), "Save to disk");
          ToolStripButton[] openSaveButtonArr2 = new ToolStripButton[] { tsbOpen2, tsbSave2 };
          ToolStrip openSaveToolStrip2 = new ToolStrip(openSaveButtonArr2) { CanOverflow = true };
          this.tsPanel.Join(openSaveToolStrip2, 1);      
          //
          // third toolstrip
          //
          WebClient wc = new WebClient();
          byte[] bytes = wc.DownloadData("http://my.crestron.eu/images/icons/ico_folder_open.png");
          // You must keep the stream open for the lifetime of the Image.
          MemoryStream msOpen = new MemoryStream(bytes);
          System.Drawing.Image imgOpen = System.Drawing.Image.FromStream(msOpen);
    
          bytes = wc.DownloadData("http://www.njrussians.com/images/save_ico.png");
          MemoryStream msSave = new MemoryStream(bytes);
          System.Drawing.Image imgSave = System.Drawing.Image.FromStream(msSave);
          ToolStripButton tsbOpen3 = createToolStripButton("Open3", imgOpen, new EventHandler(this.OnOpen), "Open saved file");
          ToolStripButton tsbSave3 = createToolStripButton("Save3", imgSave, new EventHandler(this.OnSaveToDisk), "Save to disk");
          ToolStripButton[] openSaveButtonArr3 = new ToolStripButton[] { tsbOpen3, tsbSave3 };
          ToolStrip openSaveToolStrip3 = new ToolStrip(openSaveButtonArr3) { CanOverflow = true };
          this.tsPanel.Join(openSaveToolStrip3, 2);     
          
        }
    
        ToolStripButton createToolStripButton (string text, Image i, EventHandler eh, string name)
        {
          return new ToolStripButton(text, i, eh, name);
        }
    
        void MFDesigner_Resize (object sender, System.EventArgs e) { }
    
        void MFDesigner_Load (object sender, System.EventArgs e) { }
    
        void OnOpen (object target, EventArgs e) { }
    
        void OnSaveToDisk (object target, EventArgs e) { }
    
        #region Windows Form Designer generated code
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
    
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
          if (disposing && (components != null))
          {
            components.Dispose();
          }
          base.Dispose(disposing);
        }
    
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
          this.tsPanel = new System.Windows.Forms.ToolStripPanel();
          this.SuspendLayout();
          // 
          // tsPanel
          // 
          this.tsPanel.Dock = System.Windows.Forms.DockStyle.Top;
          this.tsPanel.Location = new System.Drawing.Point(0, 0);
          this.tsPanel.Margin = new System.Windows.Forms.Padding(3);
          this.tsPanel.Name = "tsPanel";
          this.tsPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
          this.tsPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
          this.tsPanel.Size = new System.Drawing.Size(984, 0);
          // 
          // MFDesigner
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.Gainsboro;
          this.ClientSize = new System.Drawing.Size(984, 632);
          this.Controls.Add(this.tsPanel);
          this.ForeColor = System.Drawing.Color.Black;
          this.Name = "MFDesigner";
          this.Text = "MFDesigner";
          this.Load += new System.EventHandler(this.MFDesigner_Load);
          this.Resize += new System.EventHandler(this.MFDesigner_Resize);
          this.ResumeLayout(false);
          this.PerformLayout();    
        }    
    
    
        #endregion    
      }
  
