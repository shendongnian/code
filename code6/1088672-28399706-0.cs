    var query = from v in various
                where vComboBox == v.GetName()
                select v.Description();
     StringBuilder sb = new StringBuilder();
     foreach (var vr in query)
     {
         sb.AppendLine(vr);
     }
     descriptionTextBox.Text = sb.ToString();
