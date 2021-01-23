    public static DialogResult InputBox<KeyType, ValueType>(string aTitle, string aPromptText, Dictionary<KeyType, ValueType> aDictionary, ref  KeyValuePair<KeyType, ValueType> aReturnPair, Func<ValueType, string> aDelegate)
        {
            Form lForm = new Form();
            Label lLabel = new Label();
            ComboBox lComboBox = new ComboBox();
            Button lButtonOk = new Button();
            Button lButtonCancel = new Button();
            lForm.Text = aTitle;
            lLabel.Text = aPromptText;
            foreach (KeyValuePair<KeyType, ValueType> lPair in aDictionary)
            {
                lComboBox.Items.Add(aDelegate(lPair.Value));
            }
            
            lButtonOk.Text = "OK";
            lButtonCancel.Text = "Cancel";
            lButtonOk.DialogResult = DialogResult.OK;
            lButtonCancel.DialogResult = DialogResult.Cancel;
            lLabel.SetBounds(9, 20, 372, 13);
            lComboBox.SetBounds(12, 36, 372, 20);
            lButtonOk.SetBounds(228, 72, 75, 23);
            lButtonCancel.SetBounds(309, 72, 75, 23);
            lLabel.AutoSize = true;
            lComboBox.Anchor = lComboBox.Anchor | AnchorStyles.Right;
            lButtonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lButtonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lForm.ClientSize = new Size(396, 107);
            lForm.Controls.AddRange(new Control[] { lLabel, lComboBox, lButtonOk, lButtonCancel });
            lForm.ClientSize = new Size(Math.Max(300, lLabel.Right + 10), lForm.ClientSize.Height);
            lForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            lForm.StartPosition = FormStartPosition.CenterScreen;
            lForm.MinimizeBox = false;
            lForm.MaximizeBox = false;
            lForm.AcceptButton = lButtonOk;
            lForm.CancelButton = lButtonCancel;
            DialogResult dialogResult = lForm.ShowDialog();
            if ((dialogResult == DialogResult.OK) && (lComboBox.SelectedIndex > -1) && (lComboBox.SelectedIndex < aDictionary.Count))
            {
                foreach (KeyValuePair<KeyType, ValueType> lPair in aDictionary)
                {
                    if (string.Compare(aDelegate(lPair.Value),lComboBox.Items[lComboBox.SelectedIndex].ToString())== 0)
                    {
                        aReturnPair = lPair;
                    }
                }
            }            
            return dialogResult;
        }
