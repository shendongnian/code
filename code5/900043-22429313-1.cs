    void Btn_addClick(object sender, EventArgs e)
    {      
        string text = textBox1.Text;
        bool isDuplicate = false;
        foreach (var name in ListBox1.Items)
        {
            if(name.ToString().Equals(text))
            {
                isDuplicate = true;
                break;
            }
        }
        if (isDuplicate) 
        {
          MessageBox.Show("This name already exists!");
        }
        else
        {
            listBox1.Items.Add(text);
            textBox1.Text = "";
        }   
    }
