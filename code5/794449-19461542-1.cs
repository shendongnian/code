    deviceSel = st.Split(splitChar);
    string toDisplay = "";
    foreach (string device in deviceSel)
    {
        toDisplay += device + Environment.NewLine;
    }
    MessageBox.Show(toDisplay);
