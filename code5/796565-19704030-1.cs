    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AddMenuElements(7);
        }
        public void AddMenuElements(int licznik)
        {
            ToolStripMenuItem wszystkie = new ToolStripMenuItem("wszystkie", SystemIcons.Question.ToBitmap());
            manu1ToolStripMenuItem.DropDownItems.Add(wszystkie);
            menuStrip1.Renderer = new ToolStripSystemRenderer();
            for (int i = 0; i < licznik; i++)
            {
                ToolStripMenuItem element = new ToolStripMenuItem(String.Format("element {0}", i), GetIcon(i),element2_Click);
                element.Visible = i % 2 == 0 ? false:true;                
                manu1ToolStripMenuItem.DropDownItems.Add(element);
            }
            
            
            for (int i = 0; i < licznik; i++)
            {
                MyControl element2 = new MyControl(String.Format("element {0}",i), GetIcon(i),element2_Click);
                element2.ID = i;
                element2.CheckedChanged += (s, e) =>
                {                    
                    MyControl control = s as MyControl;
                    manu1ToolStripMenuItem.DropDownItems[control.ID + 1].Visible = control.Checked;                  
                };
                element2.Checked = i % 2 == 0 ? false : true;
               
                wszystkie.DropDownItems.Add(element2); 
                
            }
        }
        void element2_Click(object sender, EventArgs e)
        {
            MyControl kontener = (sender as MyControl);
            if (kontener.ForeColor == Color.Red)
                kontener.ForeColor = Color.Black;
            else
                kontener.ForeColor = Color.Red;
        }
        private static Image GetIcon(int i)
        {
            Image ikona = null;
            switch (i)
            {
                case 0: ikona = SystemIcons.Application.ToBitmap();
                    break;
                case 1: ikona = SystemIcons.Asterisk.ToBitmap();
                    break;
                case 2: ikona = SystemIcons.WinLogo.ToBitmap();
                    break;
                case 3: ikona = SystemIcons.Exclamation.ToBitmap();
                    break;
                case 4: ikona = SystemIcons.Hand.ToBitmap();
                    break;
                case 5: ikona = SystemIcons.Warning.ToBitmap();
                    break;
                default: ikona = SystemIcons.Shield.ToBitmap();
                    break;
            }
            return ikona;
        }   
    }
 
