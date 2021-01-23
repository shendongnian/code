    if ((bool)dr[i]["HasText"] == true)
     {
        Panel pnltxt = new Panel();
        pnltxt.Size = new Size(630, 30);
        int index = i;
        chlb.SelectedIndexChanged += (s, argx) => pnltxt.Enabled =(chlb.GetItemCheckState(index).ToString().Trim() == "Unchecked" ? false : true);
     }
