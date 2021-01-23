         string foo = "bar";
		 var resources = Project.Properties.Resources;
		 object o = resources.GetType().GetProperty(foo).GetValue(resources, null);
		 if (o is System.Drawing.Image) {
		 		pictureBox.Image = (System.Drawing.Image) o;
		 }
