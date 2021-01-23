    string str = yourTextBoxValue.Text;
    string[] strs = str.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
    int param1 = int.Parse(strs[0]);
    int param2 = int.Parse(strs[1]);
    int result = param1 + param2;
    yourLabel.Text = result.ToString();
