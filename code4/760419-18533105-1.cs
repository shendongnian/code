    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Diagnostics;
    namespace FileHandling
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Check if directory exists
            if (Directory.Exists(@"C:\Users\rs\Desktop\Test\)"))
            {
                // Do nothing
            }
            else
            {
                Directory.CreateDirectory(@"C:\Users\rs\Desktop\Test\");
            }
            if (File.Exists(@"C:\Users\rs\Desktop\Test\test.txt"))
            {
                // Do nothing
            }
            else
            {
                File.Create(@"C:\Users\rs\Desktop\Test\test.txt");
            }
            using (StreamReader writer = new StreamReader(@"C:\Users\rs\Desktop\Test\test.txt"))
            {
                while (writer.Peek() >= 0)
                {
                    combox_Name2.Items.Add(writer.ReadLine());
                }
                writer.Close();
            }
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(@"C:\Users\rs\Desktop\Test\test.txt", true))
            {
                try
                {
                    if (combox_Name2.Items.Contains(txt_Name.Text))
                    {
                        MessageBox.Show("The task '" + txt_Name.Text + "' already exist in list", "Task already exists");
                    }
                    else
                    {
                        combox_Name2.Items.Add(txt_Name.Text);
                        writer.WriteLine(txt_Name.Text);
                        writer.Flush();
                        writer.Dispose();
                    }
                }
                catch
                {
                    MessageBox.Show("The file '" + txt_Name.Text + "' could not be located", "File could not be located");
                }
            }
        }
    }
    }
