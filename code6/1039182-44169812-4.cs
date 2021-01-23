        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Windows.Forms;
        using System.Threading;
        using System.IO;
        
        namespace WindowsFormsApplication1
        {
            public partial class Form1 : Form
            {
                public static int Countername1; //Calls Countername1 = 0;
        
                public Form1()
                {
                    InitializeComponent();
                    Countername1 = 0;
                }
        
                private void timer1_Tick(object sender, EventArgs e)
                {
                    try
                    {
                        Countername1++;
                        switch (Countername1)
                        {
                            case 1:
                                //You can put whatever code
                                break;
        
                            case 2:
                                //You can put whatever code
                                break;
        
                            case 3:
                                //You can put whatever code
                                break;
        
                            case 4:
                                //You can put whatever code
                                break;
        
                            case 5:
                                this.Close(); //You can put whatever code
                                timer1.Stop(); //You can put whatever code
                                break;
                        }
                        if (Countername1 == 5)
                        {
                            Countername1 = 0;
                        }
                    }
                    catch
                    {
        
                    }
                }
            }
        }
