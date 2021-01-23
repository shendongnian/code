    string Str = textBoxUPC.Text;
    double Num;
    bool isNum = double.TryParse(Str, out Num);
    if (isNum)
    {
     //your code here...
    }
    else
    {
    //display error here...
    }
