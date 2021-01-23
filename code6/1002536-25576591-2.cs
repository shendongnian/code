	internal class SpecialTextBoxDesigner
     : System.Windows.Forms.Design.ControlDesigner
	{
		public override void InitializeNewComponent(
            System.Collections.IDictionary defaultValues)
		{
			base.InitializeNewComponent(defaultValues);
			this.Control.Text = "Initial Text...";
		}
	}
