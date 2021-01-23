	var m = new List<System.Dynamic.ExpandoObject>();
	foreach (string item in new string[] { "a", "b", "c" }) {
		dynamic menuItem = new System.Dynamic.ExpandoObject();
		menuItem.pos1 = item;
		menuItem.pos2 = (item == "b" ? item : null); // wrong
		if (item == "c") {           // correct
			menuItem.pos3 = "I am at third iteration";
		}
		m.Add(menuItem);
	}
			
