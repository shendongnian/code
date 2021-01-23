    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Threading;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Animate a = new Animate(panel1,0,0,1,1); //this is the actual instatiation test
            Animate b = new Animate(panel1, 100, 0,2,2); //for node b
            
        }
        public class Animate
        {
            private Node l;
            Thread th;
            private delegate void cl(int x, int y);
            Delegate del;
            private int a, b;
            public Animate(Panel p, int x, int y, int a, int b)
            {
                l = new Node(0,0);
                del = new cl(l.updatePos);
                this.a = a;
                this.b = b;
                this.l.AutoSize = true;
                this.l.Location = new System.Drawing.Point(x, y);
                this.l.Name = "label1";
                this.l.Size = new System.Drawing.Size(35, 13);
                this.l.TabIndex = 0;
                this.l.Text = "label1";
                p.Controls.Add(l);
                th = new Thread(thread);
                th.Start();
            }
            private void thread()
            {
                while (true)
                {
                    try
                    {
                        l.Invoke(del, a, b);
                        Thread.Sleep(100);
                    }
                    catch (Exception e)
                    {
                        return;
                    }
                }
            }
        }
    }
