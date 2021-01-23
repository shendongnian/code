    switch (child.Name)
    {
        case "textbox":
            String txtlabel = child.Attributes["label"].Value;
            TextBoxControl txtctrl = new TextBoxControl(txtlabel);
            txtctrl.Content = (String)info.Data[i];
            txtctrl.SetDisplay((String)info.Data[i]);
            txtctrl.Margin = new Padding(1, 1, 1, 1); // <---- or whatever you like
            panel.Controls.Add(txtctrl);
            panel.Width = txtctrl.Width;
            break;
        case "combobox":
            String combolabel = child.Attributes["label"].Value;
            ComboBoxControl comboctrl = new ComboBoxControl(combolabel,
                                                           (String[])info.Data[i]);
            comboctrl.Content = (String[])info.Data[i];
            comboctrl.SetDisplay(0);
            comboctrl.Margin = new Padding(1, 1, 1, 1); // <----  or whatever you like
            panel.Controls.Add(comboctrl);
            panel.Width = comboctrl.Width;
            break;
        case "datetimepicker":
            String datelabel = child.Attributes["label"].Value;
            DateTimeControl datectrl = new DateTimeControl(datelabel,
                                                          (DateTime)info.Data[i]);
            datectrl.Margin = new Padding(1, 1, 1, 1); // <----  or whatever you like
            panel.Controls.Add(datectrl);
            panel.Width = datectrl.Width;
            break;
        case "#comment":
            break;
        default:
            Console.WriteLine("No Tag Found");
            break;
    }
