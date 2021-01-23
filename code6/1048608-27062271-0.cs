    private void button1_Click(object sender, EventArgs e)
    {
        //IRRELEVANT CODE ...
        using(img = ResizeImage(memory, new Size(getX(), getY())))
        {
            //IRRELEVANT CODE ...
           img.Save(outputFileName, codec, encoderParams);
        }
    }
