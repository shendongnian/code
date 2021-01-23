            string chkboxlistValue = "";
            string uncheckedId = "";
            foreach (ListItem val in chkbxId.Items)
            {
                if (val.Selected)
                {
                    chkboxlistValue += val.Value + " ";
                }
                else
                {
                     uncheckedId += val.Value + ",";
                }
            }
