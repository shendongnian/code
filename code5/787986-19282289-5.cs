    namespace WpfApplication1
    {
        using System;
        using System.Windows.Forms;
        using System.Windows.Media;
    
        public partial class Form1 : Form
        {
            public EventHandler<Brush> ChangedColourEventHandler;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private Brush bgColour;
            private Brush BgColour
            {
                get
                {
                    return this.bgColour;
                }
                set
                {
                    this.bgColour = value;
                    TriggerChangedColourEventHandler(value);
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                this.BgColour = (Brush)new BrushConverter().ConvertFromString("#FF00B25A");
            }
    
            private void TriggerChangedColourEventHandler(Brush color)
            {
                var handler = ChangedColourEventHandler;
                if (handler != null)
                {
                    handler(this, color);
                }
            }
        }
    }
