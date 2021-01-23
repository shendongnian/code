    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Button[] buttons = { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16, btn17, btn18, btn19, btn20, btn21, btn22, btn22, btn23, btn24, btn25, btn26, btn27, btn28, btn29, btn30 };
            //did this becz couldnt fill the array buttons with a for loop...hope if u know to tell me how
            for (int i = 0; i < 30; i++)
            {
                int n = i;
                buttons[i].Click += (object s, EventArgs ea) => ChangeImage(n);
            }
        }
        void ChangeImage(int id)
                {
    Bitmap b=new Bitmap(myProject.Properties.Resources  //how to apply the index of the button in getting the name of the image;
                    panel2.BackgroundImage=b;
            
                }
    }
