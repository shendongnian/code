    using System;
    using System.Windows.Forms;
    namespace WindowsFormsBindingDemo
    {
    public partial class BusinessesForm : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView businessesDataGridView;
        private BusinessesDataSet businessesDataSet;
        private System.Windows.Forms.BindingSource businessesBindingSource;
        private BusinessesDataSetTableAdapters.BusinessesTableAdapter businessesTableAdapter;
        private BusinessesDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private BusinessesDataSetTableAdapters.IndustriesTableAdapter industriesTableAdapter;
        private System.Windows.Forms.BindingSource industriesBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn industryIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn businessNameDataGridViewTextBoxColumn;
        public BusinessesForm()
        {
            this.components = new System.ComponentModel.Container();
            this.businessesDataGridView = new System.Windows.Forms.DataGridView();
            this.businessesDataSet = new WindowsFormsBindingDemo.BusinessesDataSet();
            this.businessesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.businessesTableAdapter = new WindowsFormsBindingDemo.BusinessesDataSetTableAdapters.BusinessesTableAdapter();
            this.tableAdapterManager = new WindowsFormsBindingDemo.BusinessesDataSetTableAdapters.TableAdapterManager();
            this.industriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.industriesTableAdapter = new WindowsFormsBindingDemo.BusinessesDataSetTableAdapters.IndustriesTableAdapter();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.industryIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.businessNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.businessesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.businessesDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.businessesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.industriesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // businessesDataGridView
            // 
            this.businessesDataGridView.AutoGenerateColumns = false;
            this.businessesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.businessesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.industryIDDataGridViewTextBoxColumn,
            this.businessNameDataGridViewTextBoxColumn});
            this.businessesDataGridView.DataSource = this.businessesBindingSource;
            this.businessesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.businessesDataGridView.Location = new System.Drawing.Point(0, 0);
            this.businessesDataGridView.Name = "businessesDataGridView";
            this.businessesDataGridView.RowTemplate.Height = 24;
            this.businessesDataGridView.Size = new System.Drawing.Size(554, 374);
            this.businessesDataGridView.TabIndex = 0;
            // 
            // businessesDataSet
            // 
            this.businessesDataSet.DataSetName = "BusinessesDataSet";
            this.businessesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // businessesBindingSource
            // 
            this.businessesBindingSource.DataMember = "Businesses";
            this.businessesBindingSource.DataSource = this.businessesDataSet;
            // 
            // businessesTableAdapter
            // 
            this.businessesTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BusinessesTableAdapter = this.businessesTableAdapter;
            this.tableAdapterManager.IndustriesTableAdapter = this.industriesTableAdapter;
            this.tableAdapterManager.UpdateOrder = WindowsFormsBindingDemo.BusinessesDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // industriesBindingSource
            // 
            this.industriesBindingSource.DataMember = "Industries";
            this.industriesBindingSource.DataSource = this.businessesDataSet;
            // 
            // industriesTableAdapter
            // 
            this.industriesTableAdapter.ClearBeforeFill = true;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // industryIDDataGridViewTextBoxColumn
            // 
            this.industryIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.industryIDDataGridViewTextBoxColumn.DataPropertyName = "IndustryID";
            this.industryIDDataGridViewTextBoxColumn.DataSource = this.industriesBindingSource;
            this.industryIDDataGridViewTextBoxColumn.DisplayMember = "IndustryName";
            this.industryIDDataGridViewTextBoxColumn.FillWeight = 300F;
            this.industryIDDataGridViewTextBoxColumn.HeaderText = "IndustryID";
            this.industryIDDataGridViewTextBoxColumn.Name = "industryIDDataGridViewTextBoxColumn";
            this.industryIDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.industryIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.industryIDDataGridViewTextBoxColumn.ValueMember = "ID";
            // 
            // businessNameDataGridViewTextBoxColumn
            // 
            this.businessNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.businessNameDataGridViewTextBoxColumn.DataPropertyName = "BusinessName";
            this.businessNameDataGridViewTextBoxColumn.FillWeight = 300F;
            this.businessNameDataGridViewTextBoxColumn.HeaderText = "BusinessName";
            this.businessNameDataGridViewTextBoxColumn.Name = "businessNameDataGridViewTextBoxColumn";
            // 
            // BusinessesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 374);
            this.Controls.Add(this.businessesDataGridView);
            this.Name = "BusinessesForm";
            this.Text = "Businesses";
            this.Load += new System.EventHandler(this.BusinessesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.businessesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.businessesDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.businessesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.industriesBindingSource)).EndInit();
            this.ResumeLayout(false);
        }
        private void BusinessesForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'businessesDataSet.Industries' table. You can move, or remove it, as needed.
            this.industriesTableAdapter.Fill(this.businessesDataSet.Industries);
            // TODO: This line of code loads data into the 'businessesDataSet.Businesses' table. You can move, or remove it, as needed.
            this.businessesTableAdapter.Fill(this.businessesDataSet.Businesses);
        }
       
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
    }
}
