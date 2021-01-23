    Steema.TeeChart.TChart tChart1; 
    public Form1()
    {
        InitializeComponent();
        tChart1 = new TChart();
        this.Controls.Add(tChart1);
        tChart1.Top = 150;
        tChart1.Left = 100;
        tChart1.Height = 400;
        tChart1.Width = 550; 
        InitializeChart();
    }
    Steema.TeeChart.Styles.Bar series1, series2, series3,series4;
    Steema.TeeChart.Axis axis1; 
    
    private void InitializeChart()
    {
        tChart1.Aspect.View3D = false; 
        series1 = new Bar(tChart1.Chart);
        series2 = new Bar(tChart1.Chart);
        series3 = new Bar(tChart1.Chart);
        series4 = new Bar(tChart1.Chart); 
        axis1 = new Axis(tChart1.Chart);  
        tChart1.Axes.Custom.Add(axis1); 
        series1.FillSampleValues();
        series2.FillSampleValues();
        series3.FillSampleValues(); 
        series4.FillSampleValues();
        series1.Marks.Visible = false;
        series2.Marks.Visible = false;
        series3.Marks.Visible = false;
        series4.Marks.Visible = false; 
        axis1.RelativePosition = tChart1.Panel.MarginLeft -12;
        tChart1.Panel.MarginLeft = 10; 
        axis1.Horizontal = false;
        series1.CustomVertAxis = axis1;
        series1.MultiBar = MultiBars.SelfStack;
        button1.Click +=button1_Click;
    }
