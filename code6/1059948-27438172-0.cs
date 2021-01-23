            string chkboxlistValue = "";
            string UncheckedId = "";
            foreach (ListItem val in chkbxId.Items)
            {
                if (val.Selected)
                {
                    chkboxlistValue += val.Value + " ";
                }
                else
                {
                     UncheckedId += val.Value + ",";
                }
            }
