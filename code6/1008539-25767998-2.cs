    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    public partial class Form1 : Form
    {
        private List<ControlScaler> _buttonsToScale = new List<ControlScaler>();
        public Form1()
        {
            InitializeComponent();
            // Has to happen AFTER InitializeComponent is called!
            _buttonsToScale.Add(new ControlScaler(btn1, pictureBox1));
            _buttonsToScale.Add(new ControlScaler(btn2, pictureBox1));
        }
        private void pictureBoxResize(object sender, EventArgs e)
        {
            foreach (var control in _buttonsToScale)
                control.AdjustPositionToScale();
        }
    }
    public class ControlScaler
    {
        // X, Y scaling variables
        private float _btn1xScale;
        private float _btn1yScale;
        private Control _scaledControl;
        private readonly Control _scaleTo;
        public ControlScaler(Control scaledControl, Control scaleTo)
        {
            _scaledControl = scaledControl;
            _scaleTo = scaleTo;
            _btn1xScale = scaledControl.Location.X / (float)scaleTo.Width;
            _btn1yScale = scaledControl.Location.Y / (float)scaleTo.Height;
        }
        public void AdjustPositionToScale()
        {
            var newLocation = new Point(
                (int)(_scaleTo.Width * _btn1xScale),
                (int)(_scaleTo.Height * _btn1yScale));
            _scaledControl.Location = newLocation;
        }
    }
