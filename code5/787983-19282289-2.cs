    namespace WpfApplication1
    {
        using System;
        using System.Windows.Forms;
        using System.Windows.Media;
    
        public partial class Form1 : Form
        {
            public EventHandler ChangedColourEventHandler;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private Brush bgColour;
            public Brush BgColour
            {
                get
                {
                    return this.bgColour;
                }
                private set
                {
                    this.bgColour = value;
                    TriggerChangedColourEventHandler();
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                this.BgColour = (Brush)new BrushConverter().ConvertFromString("#FF00B25A");
            }
    
            private void TriggerChangedColourEventHandler()
            {
                var handler = ChangedColourEventHandler;
                if (handler != null)
                {
                    handler(this, null);
                }
            }
        }
    }
