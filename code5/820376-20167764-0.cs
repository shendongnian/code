    string myOutput = "image.png";
    string statementOutput = "";
    if (myOutput.Contains("youtu.be"))
    {
        statementOutput = "Video ouput";
    }
    else
    {
        if (myOutput.Contains(".png"))
        {
            statementOutput = "Image output";
        }
        else
        {
            statementOutput = "Nothing's here";
        }
    }
    Label1.Text = statementOutput;
