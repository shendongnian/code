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
        public partial class frmButtons : Form
        {
            private Int32 _selectedButton = 1;
            private Dictionary<Int32, Button> _buttonDict = new Dictionary<Int32, Button>();
    
            public frmButtons()
            {
                InitializeComponent();
    
                foreach (Button b in this.Controls.OfType<Button>().Where(x => x.Tag != null))
                {
                    Int32 i;
                    if (Int32.TryParse(b.Tag.ToString(), out i))
                        _buttonDict.Add(i, b);
                }
                if (_buttonDict.Count > 0)
                    _buttonDict[_selectedButton].Focus();
            }
    
            private void frmButtons_KeyUp(Object sender, KeyEventArgs e)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        _selectedButton -= 3;
                        e.Handled = true;
                        break;
                    case Keys.Down:
                        _selectedButton += 3;
                        e.Handled = true;
                        break;
                    case Keys.Left:
                        _selectedButton -= 1;
                        e.Handled = true;
                        break;
                    case Keys.Right:
                        _selectedButton += 1;
                        e.Handled = true;
                        break;
                    case Keys.Enter:
                        break;
                }
    
                if (_selectedButton < 1)
                    _selectedButton += 12;
                else if (_selectedButton > 12)
                    _selectedButton -= 12;
                _buttonDict[_selectedButton].Focus();
            }
        }
    }
