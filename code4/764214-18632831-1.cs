    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace CpuUsageTest
    {
    public partial class frmCpuUsage : Form
    {
    public frmCpuUsage()
    {
    InitializeComponent();
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
    
    }
    
    private void timer1_Tick(object sender, EventArgs e)
    {
    progressBar1.Value = (int)(performanceCounter1.NextValue());
    label1.Text = "Processor Time: " + 
    progressBar1.Value.ToString() + "%";
    }
    }
    }
