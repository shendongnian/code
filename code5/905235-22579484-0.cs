    double sum1 =0.0 ;
    private void add_Click(object sender, RoutedEventArgs e)
    {
        sum1 += double.Parse(numEnt.Text);
        numEnt.Clear();
        plusButtonClicked = true;
        subButtonClicked = false;
        multButtonClicked = false;
        divButtonClicked = false;
    }
    private void sub_Click(object sender, RoutedEventArgs e)
    {
        sum1 -= double.Parse(numEnt.Text);
        numEnt.Clear();
        plusButtonClicked = false;
        subButtonClicked = true;
        multButtonClicked = false;
        divButtonClicked = false;
    }
    private void mult_Click(object sender, RoutedEventArgs e)
    {
        sum1 *= double.Parse(numEnt.Text);
        numEnt.Clear();
        plusButtonClicked = false;
        subButtonClicked = false;
        multButtonClicked = true;
        divButtonClicked = false;
    }
    private void div_Click(object sender, RoutedEventArgs e)
    {
        sum1 /= double.Parse(numEnt.Text);
        numEnt.Clear();
        plusButtonClicked = false;
        subButtonClicked = false;
        multButtonClicked = false;
        divButtonClicked = true;
    }
    private void deci_Click(object sender, RoutedEventArgs e)
    {
        string currentInput = numEnt.Text;
        bool pointFound = false;
        //for (int i = 0; i < currentInput.Length; i++)
        //{
            if(currentInput.Contains("."))//if (currentInput[i] == '.')
                pointFound = true;
        //}
        if (pointFound == false)
            numEnt.Text += ".";
    }
