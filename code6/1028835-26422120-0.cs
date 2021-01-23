    class MyClass : Form
    {
        public MyClass()
        {
            if (File.Exists("ListBoxItems.txt"))
            {
                using (StreamReader sr = new StreamReader("ListBoxItems.txt"))
                {
                    while (sr.Peek() != -1)
                    {
                        myListBox.Items.Add(sr.ReadLine());
                    }
                }
            }
        }
        //Other class functions here
    }
