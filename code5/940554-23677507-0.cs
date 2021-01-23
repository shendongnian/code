    private List<Label> labels = new List<Label>();
    private List<TextBox> textBoxes = new List<TextBox>();
    public MyForm()
    {
        labels.Add(myLabel1);
        labels.Add(myLabel2);
        labels.Add(myLabel3);
        textBoxes.Add(myTB1);
        textBoxes.Add(myTB2);
        textBoxes.Add(myTB3);
    }
    private void addValuesFromDictionary(Dictionary<string, string> dic)
    {
        for (int i = 0; i < dic.Count; i++)
        {
            labels[i].Text = dic[i].Key;
            textBoxes[i].Text = dic[i].Value;
        }
    }
