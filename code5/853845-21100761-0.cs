     private void Form1_Load(object sender, EventArgs e)
            {
    
                List<int> myList = new List<int>() {1,2,3,4,5 };
                listBox1.DataSource = myList;
    
                
                foreach (var item in tabControl1.TabPages)
                {
                    MyTabPages.Add(item as TabPage);
                }
                
            }
    
            List<TabPage> MyTabPages = new List<TabPage>();
    
    
            private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (MyTabPages.Count == 0)
                {
                    return;
                }
    
                Int32 Index = listBox1.SelectedIndex;
                if (Index >= 0 && Index <= MyTabPages.Count - 1)
                {
                    if(tabControl1.TabPages.IndexOf(MyTabPages[Index]) < 0)
                    {
                        tabControl1.TabPages.Add(MyTabPages[Index]);
                    }
                    else
                    {
                        tabControl1.TabPages.Remove(MyTabPages[Index]);
                    }
                }
            }
