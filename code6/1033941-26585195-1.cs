    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace reach_test {
        public partial class Form1 : Form {
            public Form1() {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e) {
                Class1 formName = new Class1(); // this line compiles OK.
               this.text= formName.someMethod();          // this line compiles OK.
            }
        }
    }
