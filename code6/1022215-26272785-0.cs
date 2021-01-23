    using System;
    using System.Windows;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.Threading;
    namespace nonblock
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private ListBox l1;
            private ListBox l2;
            private Thread workThread;
            private Thread nonBlockThread;
            private List<TwoNumbers> list;
            private void Form1_Load(object sender, EventArgs e)
            {
                this.Size = new Size(500,500);
                this.FormClosing += (ss, ee) =>
                {
                    workThread.Abort();
                    nonBlockThread.Abort();
                };
                l1 = new ListBox();
                l1.Dock = DockStyle.Left;
                l2 = new ListBox();
                l2.Dock = DockStyle.Right;
                list = new List<TwoNumbers>();
                this.Controls.Add(l1);
                this.Controls.Add(l2);
                workThread = new Thread(work);
                workThread.Start();
                nonBlockThread = new Thread(update);
                nonBlockThread.Start();
            }
            private void work()
            {
                int a = 0;
                int b = 0;
                int counter = 0;
                Random r = new Random();
                while (true)
                {
                    a += r.Next();
                    b += r.Next();
                    counter++;
                    if (counter % 10 == 0)
                        list.Add(new TwoNumbers(a, b));
                    Thread.Sleep(40);
                }
            }
            private void update()
            {
                while (true)
                {
                    if (list.Count > 0)
                    {
                        for (int a = 0; a < list.Count; a++)
                        {
                            l1.Invoke((MethodInvoker)(() => l1.Items.Add(list[0].n1)));
                            l2.Invoke((MethodInvoker)(() => l2.Items.Add(list[0].n2)));
                            list.RemoveAt(0);
                        }
                    }
                    Thread.Sleep(1000);
                }
            }
            public class TwoNumbers
            {
                public int n1 { get; set; }
                public int n2 { get; set; }
                public TwoNumbers(int a, int b)
                {
                    n1 = a;
                    n2 = b;
                }
            }
        }
    }
