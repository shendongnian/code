    IEnumerable<string> Test()
    {
        for (int i = 1; i < ProductArray.Length; i++)
        {
            Label lbl = new Label();
            ThresholdPanel.Controls.Add(lbl);
            lbl.Top = A * 28;
            lbl.Left = 15;
            lbl.Font = new Font(lbl.Font, FontStyle.Bold);
            lbl.Text = ProductArray[i];
            lbl.Name = "Label" + ProductArray[i];
            TextBox txt = new TextBox();
            ThresholdPanel.Controls.Add(txt);
            txt.Top = A * 28;
            txt.Left = 125;
            //txt.Text = "Text Box All" + this.A.ToString();
            txt.Name = "txt" + A;
            textBoxes[txt.Name] = txt;
            A = A + 1;
            yield return txt;
        }
    }
