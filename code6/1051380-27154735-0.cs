    dynamic setSelector;
    private void Form1_Load(object sender, EventArgs e)
    {
        if(appColor == "blue")
        {
            setSelector = Properties.myset1.Default;
        }
        else if(appColor == "red")
        {
           setSelector = Properties.myset2.Default;
        }
        textBox1.Text = setSelector.qty.ToString();
        }
    }
