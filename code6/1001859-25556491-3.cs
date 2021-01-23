    string Str = textBoxUPC.Text;
    long Num;
    bool isNum = long.TryParse(Str, out Num);
    if (isNum)
    {
     //your code here...
    }
    else
    {
    //display error here...
    }
