    if (Average >= 75)
    {
        lblOutput.Text += Name +" " + Surname + ", " + "your average was: " + Average + ", you shall recieve a bursary!";
    }
    else if (Average >= 35)
    {
        lblOutput.Text += Name +" " + Surname + ", " + "your average was: " + Average + ", you shall not revieve a bursary!";
    }
    else
    {
        MessageBox.Show("you failed");
    }
