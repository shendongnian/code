    using (var dReader = cmd.ExecuteReader()) {
        if (dReader != null) {
            while (dReader.Read()) {
                LinkButton btn = new LinkButton();
                //You should change the offset if you want to edit the query
                //In your case 0 is name and 1 is link
                btn.Text = dReader.GetString(0);
                btn.PostBackUrl = dReader.GetString(1);
                panel.Controls.Add(btn);
            }
        }
    }
