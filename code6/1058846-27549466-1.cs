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
        public partial class Form2 : Form
        {
            private Form1 m_form1;
            //在建立form2時得到form1的記憶體位置，
            //這樣之後就可以改form1的參數，也就是將form1顯示出來
            public Form2(Form1 p_form1)
            {
                InitializeComponent();
                //將form1的記憶體位址存起來
                m_form1 = p_form1;
            }
    
            /***
             * 這個按鈕的主要供能是將form2切換回form1
             **/
            private void button1_Click(object sender, EventArgs e)
            {
                //將form2隱藏
                this.Visible = false;
                //顯示form1
                m_form1.Visible = true;
                //關閉form2
                this.Close();
            }
    
            private void Form2_FormClosing(object sender, FormClosingEventArgs e)
            {
                //顯示form1
                //加這行的主要目的是避免使用者在form2時就將form2直接關閉，
                //而不是按了切換回form1的按鈕後才關閉，
                //因此這樣就會導致了form1還在隱藏而沒有被關閉的情況發生，但是也無法被控制。
                //以寫程式來說，再次編寫程式就會編譯失敗
                //以執行面來說，就會有多餘的process佔著cpu和記憶體空間，不划算。
                m_form1.Visible = true;
                //此時就可以關閉form1，當然沒有將form1切回visible也可以關閉，
                //只是少了form1跳出立刻消失的關閉動畫~XD
                m_form1.Close();
            }
        }
    }
