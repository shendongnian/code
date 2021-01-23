        private static HtmlGenericControl GenerateList(int count)
        {
            HtmlGenericControl parent = new HtmlGenericControl("ul");
            for (int i = 1; i <= count; i++)
            {
                HtmlGenericControl ChildLi = new HtmlGenericControl("li");
                ChildLi.InnerText = i.ToString();
                HtmlGenericControl ChildUl = new HtmlGenericControl("ul");
                ChildLi.Controls.Add(ChildUl);
                for (int j = 1; j <= i; j++) {
                    HtmlGenericControl FinalLi = new HtmlGenericControl("li");
                    FinalLi.InnerText = j.ToString();
                    ChildUl.Controls.Add(FinalLi);
                }
                parent.Controls.Add(ChildLi);
            }
            return parent;
        }
