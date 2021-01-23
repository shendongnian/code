    string numberString = text.Remove(3);
    int number;
    if(int.TryParse(numberString, out number))
    {
        //ArrayList List = new ArrayList(); you would create a new list over and over so remove this line
        if (!theList.Contains(number))     //Equals
        {
            theList.Add(number);    //list.Insert(1, number);
            MessageBox.Show(string.Format("{0} added",number));
        }
        else
        {
            MessageBox.Show("already exist");
        }
    }
    else MessageBox.Show("invalid number entered");
