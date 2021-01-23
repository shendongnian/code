    public Form1(string filename)
            {
                InitializeComponent();
                //get all the text of text file
                string[] readText = System.IO.File.ReadAllLines(filename);
                //insert the string array in your richtextbox
                foreach (string s in readText)
                {
                    richTextBox1.Text += s + Environment.NewLine;
                }
            }
