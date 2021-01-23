    if (screenToPrint.InvokeRequired) //&& this.Visible)
    {
        try
        {
            this.Invoke(new Action<AppendToScreenParam>(AppendTextFullConfig), new object[] { append });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        return;
    }
    else
    {
        screenToPrint.SelectionFont = font;
        screenToPrint.SelectionColor = append.Color;
        //screenToPrint.AppendText(append.Message);
        string TextToPrint = string.Format("{0}\n", append.Message);
        screenToPrint.AppendText(TextToPrint);
    }
}
