    List<ListBox> listBoxes = new List<ListBox>();
            foreach (Control c in Controls)
                if (c is ListBox)
                    listBoxes.Add(c as ListBox);
            int maxLineCount = listBoxes.Max(lb => lb.Items.Count);
            StringBuilder sb = new StringBuilder();
            
            for (int rowIndex = 0; rowIndex < maxLineCount; rowIndex++)
            {                
                for (int coulumnIndex = 0; coulumnIndex < listBoxes.Count; coulumnIndex++)
                {
                    if (listBoxes[coulumnIndex].Items.Count > rowIndex)
                        sb.Append(listBoxes[coulumnIndex].Items[rowIndex]);
                    sb.Append(", ");
                }
                sb.AppendLine();
            }
            File.WriteAllText("c:\\mytext.txt", sb.ToString());           
