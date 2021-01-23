    private void button1_Click(object sender, EventArgs e)
    {
        int val;
        if (int.TryParse(textBox1.Text, out val))
        {
          List<myClass> myList = new List<myClass>();
          myList.Add(new myClass { Skaitlis1 = val });
          foreach (myClass pers in myList)
          {
              listBox1.Items.Add(pers.Skaitlis1);
          }
        }
        else
        {
          MessageBox.Show("Invalid value.  Must be numeric.");
        }
    }
    
    class myClass
    {
        public int Skaitlis1 {get; set;}
    }
