            if (checkBox1.Checked)
            {
                checkBox1.CheckedChanged -= checkBox1_CheckedChanged;
                checkBox1.Checked = false;
                checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            }
        }`
