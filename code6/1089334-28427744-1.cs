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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonAddKeyValuePair = new System.Windows.Forms.Button();
            this.tboxValue = new System.Windows.Forms.TextBox();
            this.tboxKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxDictionaryView = new System.Windows.Forms.ListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAddKeyValuePair);
            this.groupBox1.Controls.Add(this.tboxValue);
            this.groupBox1.Controls.Add(this.tboxKey);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 113);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New key-value pair";
            // 
            // buttonAddKeyValuePair
            // 
            this.buttonAddKeyValuePair.Location = new System.Drawing.Point(93, 78);
            this.buttonAddKeyValuePair.Name = "buttonAddKeyValuePair";
            this.buttonAddKeyValuePair.Size = new System.Drawing.Size(75, 23);
            this.buttonAddKeyValuePair.TabIndex = 2;
            this.buttonAddKeyValuePair.Text = "Add";
            this.buttonAddKeyValuePair.UseVisualStyleBackColor = true;
            this.buttonAddKeyValuePair.Click += new System.EventHandler(this.buttonAddKeyValuePair_Click);
            // 
            // tboxValue
            // 
            this.tboxValue.Location = new System.Drawing.Point(68, 50);
            this.tboxValue.Name = "tboxValue";
            this.tboxValue.Size = new System.Drawing.Size(100, 22);
            this.tboxValue.TabIndex = 1;
            // 
            // tboxKey
            // 
            this.tboxKey.Location = new System.Drawing.Point(68, 22);
            this.tboxKey.Name = "tboxKey";
            this.tboxKey.Size = new System.Drawing.Size(100, 22);
            this.tboxKey.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Value:";
            // 
            // listBoxDictionaryView
            // 
            this.listBoxDictionaryView.FormattingEnabled = true;
            this.listBoxDictionaryView.ItemHeight = 16;
            this.listBoxDictionaryView.Location = new System.Drawing.Point(13, 133);
            this.listBoxDictionaryView.Name = "listBoxDictionaryView";
            this.listBoxDictionaryView.Size = new System.Drawing.Size(182, 180);
            this.listBoxDictionaryView.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Key,
            this.Value});
            this.dataGridView1.Location = new System.Drawing.Point(201, 10);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(382, 303);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // Key
            // 
            this.Key.HeaderText = "Key";
            this.Key.Name = "Key";
            this.Key.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 327);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.listBoxDictionaryView);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonAddKeyValuePair;
        private System.Windows.Forms.TextBox tboxValue;
        private System.Windows.Forms.TextBox tboxKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxDictionaryView;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
    }
