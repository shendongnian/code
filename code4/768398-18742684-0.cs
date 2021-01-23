	private void YouMethod(ReportObjects repObjs, List<string> ListaTodos)
	{
		foreach (CheckBox elemento in flowLayoutPanel1.Controls.OfType<CheckBox>())
		{
			bool enableSuppress ;
			
			//enableSuppress changes based on the the "elemento" being checked or not
			enableSuppress = !elemento.Checked ;
			
			foreach (string elemento2 in ListaTodos)
			{
				string Name = elemento.Tag.ToString();
				
				if (Name.Substring(Name.Length - 1, 1) == elemento2.Substring(elemento2.Length - 1, 1))
				{
					repObjs[Name].ObjectFormat.EnableSuppress = enableSuppress;
					repObjs[elemento2].ObjectFormat.EnableSuppress = enableSuppress;
				}
			}
		}
	}
