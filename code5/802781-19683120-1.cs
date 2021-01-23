    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.labelColorToClick = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelSummaryHeader = new System.Windows.Forms.Label();
            this.labelSummary = new System.Windows.Forms.Label();
            this.errorProviderWrongButton = new System.Windows.Forms.ErrorProvider(this.components);
            this.numericUpDownColors = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderWrongButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColors)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel.Location = new System.Drawing.Point(12, 41);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(560, 386);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // labelColorToClick
            // 
            this.labelColorToClick.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelColorToClick.Location = new System.Drawing.Point(174, 12);
            this.labelColorToClick.Name = "labelColorToClick";
            this.labelColorToClick.Size = new System.Drawing.Size(398, 23);
            this.labelColorToClick.TabIndex = 1;
            this.labelColorToClick.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(93, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.OnButtonStartClick);
            // 
            // labelSummaryHeader
            // 
            this.labelSummaryHeader.Location = new System.Drawing.Point(12, 430);
            this.labelSummaryHeader.Name = "labelSummaryHeader";
            this.labelSummaryHeader.Size = new System.Drawing.Size(75, 23);
            this.labelSummaryHeader.TabIndex = 3;
            this.labelSummaryHeader.Text = "Summary:";
            this.labelSummaryHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSummary
            // 
            this.labelSummary.Location = new System.Drawing.Point(93, 430);
            this.labelSummary.Name = "labelSummary";
            this.labelSummary.Size = new System.Drawing.Size(479, 23);
            this.labelSummary.TabIndex = 4;
            this.labelSummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorProviderWrongButton
            // 
            this.errorProviderWrongButton.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderWrongButton.ContainerControl = this;
            // 
            // numericUpDownColors
            // 
            this.numericUpDownColors.Location = new System.Drawing.Point(12, 14);
            this.numericUpDownColors.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownColors.Name = "numericUpDownColors";
            this.numericUpDownColors.Size = new System.Drawing.Size(75, 20);
            this.numericUpDownColors.TabIndex = 5;
            this.numericUpDownColors.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(584, 462);
            this.Controls.Add(this.numericUpDownColors);
            this.Controls.Add(this.labelSummary);
            this.Controls.Add(this.labelSummaryHeader);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelColorToClick);
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderWrongButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColors)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Label labelColorToClick;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelSummaryHeader;
        private System.Windows.Forms.Label labelSummary;
        private System.Windows.Forms.ErrorProvider errorProviderWrongButton;
        private System.Windows.Forms.NumericUpDown numericUpDownColors;
    }
