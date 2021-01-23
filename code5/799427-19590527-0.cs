    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace UserControls
    {
        public class CtrlBuyBook : UserControl
        {
            public int BookID { get; set; }
    
            public int Quantity
            {
                get { return (int)nudQuantity.Value; }
                set { nudQuantity.Value = value; }
            }
    
            public Image Cover
            {
                set { picCover.Image = value; }
            }
    
            public CtrlBuyBook()
            {
                InitializeComponent();
            }
    
            private void btnBuy_Click(object sender, System.EventArgs e)
            {
                OnBuyBook(EventArgs.Empty);
            }
    
            public event EventHandler<EventArgs> BuyBook;
            private void OnBuyBook(EventArgs e)
            {
                var handler = BuyBook;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
    
            private System.ComponentModel.IContainer components = null;
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
    
            private void InitializeComponent()
            {
                this.picCover = new System.Windows.Forms.PictureBox();
                this.btnBuy = new System.Windows.Forms.Button();
                this.nudQuantity = new System.Windows.Forms.NumericUpDown();
                ((System.ComponentModel.ISupportInitialize)(this.picCover)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
                this.SuspendLayout();
                this.picCover.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
                this.picCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.picCover.Location = new System.Drawing.Point(4, 4);
                this.picCover.Name = "picCover";
                this.picCover.Size = new System.Drawing.Size(143, 167);
                this.picCover.TabIndex = 0;
                this.picCover.TabStop = false;
    
                this.btnBuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.btnBuy.Location = new System.Drawing.Point(95, 177);
                this.btnBuy.Name = "btnBuy";
                this.btnBuy.Size = new System.Drawing.Size(52, 20);
                this.btnBuy.TabIndex = 2;
                this.btnBuy.Text = "Buy";
                this.btnBuy.UseVisualStyleBackColor = true;
                this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
    
                this.nudQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
                this.nudQuantity.Location = new System.Drawing.Point(4, 177);
                this.nudQuantity.Name = "nudQuantity";
                this.nudQuantity.Size = new System.Drawing.Size(85, 20);
                this.nudQuantity.TabIndex = 3;
    
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.Controls.Add(this.nudQuantity);
                this.Controls.Add(this.btnBuy);
                this.Controls.Add(this.picCover);
                this.Name = "ctrlBuyBook";
                this.Size = new System.Drawing.Size(150, 200);
                ((System.ComponentModel.ISupportInitialize)(this.picCover)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
                this.ResumeLayout(false);
            }
            private System.Windows.Forms.PictureBox picCover;
            private System.Windows.Forms.Button btnBuy;
            private System.Windows.Forms.NumericUpDown nudQuantity;
        }
    }
