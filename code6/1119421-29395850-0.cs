            List<ListBox> boxList = new List<ListBox>();
            List<string> labels = new List<string>();
            List<ValidValue> paramList = new List<ValidValue>();
            int i = 0;
            foreach (ReportParameterInfo param in parameters)
            {
                boxList.Add(new ListBox());
                paramList = param.ValidValues.ToList();
                labels.Clear();
                foreach (ValidValue val in paramList)
                {
                    labels.Add(val.Label + " - " + val.Value);
                }
                foreach (string lab in labels)
                {
                    boxList[i].Items.Add(lab);
                }
                flyGrid.RowDefinitions.Add(new RowDefinition());
                flyGrid.Children.Add(boxList[i]);
                Grid.SetRow(boxList[i], i);
                boxList[i].Margin = new Thickness(20);
                i++;
            }
