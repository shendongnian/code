    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void addFirstSlide()
        {
            PowerPoint.Slide firstSlide =  Globals.ThisAddIn.Application.ActivePresentation.Slides[1];
            PowerPoint.Shape textBox2 = firstSlide.Shapes.AddTextbox(
            Office.MsoTextOrientation.msoTextOrientationHorizontal, 50, 50, 500, 500);
            textBox2.TextFrame.TextRange.InsertAfter("firstSlide");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            addFirstSlide();
        }
    }
    }
