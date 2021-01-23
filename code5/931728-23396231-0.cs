    void Main()
    {
	var ddlLst2 = new List<string> { "Audi", "BMW", "Ford", "Vauxhall"};
            ddlLst2.Sort();
			
			var ctrls = new List<ListItem>();
			int i =0;
            foreach (var item in ddlLst2)
            {
                //DropDownList2.Items.Add(new ListItem(item));
				ListItem li = new ListItem(item);
				li.Attributes.Add("code", i.ToString());
				ctrls.Add(li);
				i++;
            }
			
			foreach (ListItem element in ctrls)
			{
				Console.WriteLine(element.Attributes["code"]);
			}
    }
