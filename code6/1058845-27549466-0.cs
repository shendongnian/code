    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace c_charp_multiform
    {
        public partial class Form1 : Form
        {
            //要建立form2的變數，這樣才能產生能夠傳參數的form
            private Form2 form2;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                //將form1隱藏
                this.Visible = false;
                //將form2給new出來，new的同時將自己的記憶體位置傳給form2
                //這樣到時候form2要切換回form1前就可以先設定要顯示form1
                form2 = new Form2(this);
                //顯示form2
                form2.Show();
            }
        }
    }
