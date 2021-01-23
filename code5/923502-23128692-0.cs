    string[] regions = {"Autralia", "Asia", "US"};
            foreach (var region in regions)
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                HtmlInputRadioButton radioButton=new HtmlInputRadioButton 
                    {Value = region,
                     Name = region};
                li.Controls.Add(radioButton);
                Label label=new Label {Text = region, CssClass = "YourCSSClass"};
                li.Controls.Add(label);
                radioList.Controls.Add(li);
            }
