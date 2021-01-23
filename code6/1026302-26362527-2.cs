    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
        DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1 = new DevExpress.XtraCharts.PointSeriesLabel();
        DevExpress.XtraCharts.PointOptions pointOptions1 = new DevExpress.XtraCharts.PointOptions();
        DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
        this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
        this.chartDataTableAdapter1 = new ChartTest.DBDataSetTableAdapters.ChartDataTableAdapter();
        this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
        this.dbDataSet1 = new ChartTest.DBDataSet();
        ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dbDataSet1)).BeginInit();
        this.SuspendLayout();
        // 
        // chartControl1
        // 
        this.chartControl1.DataAdapter = this.chartDataTableAdapter1;
        this.chartControl1.DataSource = this.bindingSource1;
        xyDiagram1.AxisX.DateTimeScaleOptions.GridAlignment = DevExpress.XtraCharts.DateTimeGridAlignment.Minute;
        xyDiagram1.AxisX.DateTimeScaleOptions.MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Minute;
        xyDiagram1.AxisX.Label.DateTimeOptions.Format = DevExpress.XtraCharts.DateTimeFormat.General;
        xyDiagram1.AxisX.Range.AlwaysShowZeroLevel = true;
        xyDiagram1.AxisX.Range.ScrollingRange.SideMarginsEnabled = true;
        xyDiagram1.AxisX.Range.SideMarginsEnabled = true;
        xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
        xyDiagram1.AxisY.Range.AlwaysShowZeroLevel = true;
        xyDiagram1.AxisY.Range.ScrollingRange.SideMarginsEnabled = true;
        xyDiagram1.AxisY.Range.SideMarginsEnabled = true;
        xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
        this.chartControl1.Diagram = xyDiagram1;
        this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.chartControl1.Legend.Visible = false;
        this.chartControl1.Location = new System.Drawing.Point(0, 0);
        this.chartControl1.Name = "chartControl1";
        this.chartControl1.SeriesDataMember = "VariableName";
        this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
        this.chartControl1.SeriesTemplate.ArgumentDataMember = "LastTime";
        this.chartControl1.SeriesTemplate.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.DateTime;
        pointSeriesLabel1.LineVisible = true;
        pointOptions1.ArgumentDateTimeOptions.Format = DevExpress.XtraCharts.DateTimeFormat.General;
        pointSeriesLabel1.PointOptions = pointOptions1;
        this.chartControl1.SeriesTemplate.Label = pointSeriesLabel1;
        this.chartControl1.SeriesTemplate.ValueDataMembersSerializable = "LastValue";
        this.chartControl1.SeriesTemplate.View = lineSeriesView1;
        this.chartControl1.Size = new System.Drawing.Size(284, 262);
        this.chartControl1.TabIndex = 0;
        // 
        // chartDataTableAdapter1
        // 
        this.chartDataTableAdapter1.ClearBeforeFill = true;
        // 
        // bindingSource1
        // 
        this.bindingSource1.DataMember = "ChartData";
        this.bindingSource1.DataSource = this.dbDataSet1;
        this.bindingSource1.Sort = "";
        // 
        // dbDataSet1
        // 
        this.dbDataSet1.DataSetName = "DBDataSet";
        this.dbDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(284, 262);
        this.Controls.Add(this.chartControl1);
        this.Name = "Form1";
        this.Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dbDataSet1)).EndInit();
        this.ResumeLayout(false);
    
    }
    
    #endregion
    
    private DevExpress.XtraCharts.ChartControl chartControl1;
    private DBDataSetTableAdapters.ChartDataTableAdapter chartDataTableAdapter1;
    private System.Windows.Forms.BindingSource bindingSource1;
    private DBDataSet dbDataSet1;
