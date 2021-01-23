    public partial class Form1 : Form {
       public Form1(){
          InitializeComponent();
          comboBox1.HandleCreated += (s,e) => {
             new NativeComboBox{StaticText = "Select Email Use"}
                               .AssignHandle(comboBox1.Handle);
          };
       }
       public class NativeComboBox : NativeWindow {
            public string StaticText { get; set; }
            
            protected override void WndProc(ref Message m)
            {                                                
                base.WndProc(ref m);
                if (m.Msg == 0xf)//WM_PAINT = 0xf
                {                    
                    var combo = Control.FromHandle(Handle) as ComboBox;
                    if (combo != null && combo.SelectedIndex == -1)
                    {
                        using (Graphics g = combo.CreateGraphics())
                        using (StringFormat sf = new StringFormat { LineAlignment = StringAlignment.Center })
                        using (Brush brush = new SolidBrush(combo.ForeColor))
                        {
                            g.DrawString(StaticText, combo.Font, brush, combo.ClientRectangle, sf);
                        }
                    }                                         
                }                
            }
        }
    }
