    private void textBox1_TextChanged(object sender, EventArgs e) {
        string _value = textBox1.Text.Trim();
        if ((textBox1.Text.Length <= 2)) {
            _value = textBox1.Text.PadLeft(3, "0", c);
        }
        
        string _changed = ".".Replace(c, "");
        int _size = _changed.Length;
        string _split1 = _changed.Substring(0, (_size - 2));
        string _split2 = _changed.Substring(_split1.Length, 2);
        _value = Convert.ToDecimal(string.Format("{0}.{1}", _split1, _split2)).ToString();
        textBox1.Text = _value;
    }
