    List<double> doubleList = new List<double>();
    private void btnGetAverage_Click(object sender, EventArgs e)
    {
        if (listBox1.SelectedIndex != -1)
        {
           var myList = listbox1.SelectedItems as List<double>;
           return myList.Average();
        }
    }
