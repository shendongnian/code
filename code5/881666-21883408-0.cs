    bool _ignore;
    private void comboBox_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        // ignore event if programmatic change
        if(_ignore)
            return;
        _ignore = true;
        // instead of push/pop can be 3 if
        var index = (sender as ComboBox).SelectedIndex; // push
        comboBox1.SelectedIndex = comboBox2.SelectedIndex = comboBox3.SelectedIndex = -1;
        (sender as ComboBox).SelectedIndex = index; // pop
        _ignore = false;
    }
