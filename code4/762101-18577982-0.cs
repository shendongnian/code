	private void ComboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
	{
         if(ComboBox1.SelectedItem==null) return;
	     var b= (Bird) ComboBox1.SelectedItem;
         if(b!=null)
             Console.WriteLine(b.Gender +" - " + b.Name +" - " + b.Risk + " - " +b.Reference);
    }
