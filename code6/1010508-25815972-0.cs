    public Form1()
    {
        InitializeComponent();
    }
    Hashtable Info = new Hashtable();
    private void AddToHashTable_Click(object sender, EventArgs e)
    {
        string a = textBox1.Text;
        string b = textBox2.Text;
        if (a == "" || b == "")
        {
            MessageBox.Show("Missing Input!");
        }
        else if(Info.ContainsKey(a) || Info.ContainsKey(b))
        {
           MessageBox.Show("Hash table already contain this key");
        }
        else
        {
            Info.Add(a);
            Info.Add(b);
            MessageBox.Show("Added successfully");
            label4.Text = a + " " + b;
        }
    }
    private void DeleteFromHashTable_Click(object sender, EventArgs e)
    {
        string a = textBox1.Text;
        string b = textBox2.Text;
        if (a == "")
        {
            MessageBox.Show("Missing Value");
        }
        else if(Info.ContainsKey(a)) // but this deletes it even if the value has not been added
        {
            MessageBox.Show(a + " has been removed");
            Info.Remove(a);
        }
        else
        {
            MessageBox.Show(a + " is not part of the hash table");
        }
        //same check here for b
        if (b == "")
        {
            MessageBox.Show("Missing Value");
        }
        else if(Info.ContainsKey(b)) // but this deletes it even if the value has not been added
        {
            MessageBox.Show(b + " has been removed");
            Info.Remove(b);
        }
        else
        {
            MessageBox.Show(b + " is not part of the hash table");
        }
        
    }
