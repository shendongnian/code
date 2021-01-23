    public void Include(MvxAutoCompleteTextView text)
    		{
    			text.TextChanged += (sender, args) => text.Text = "" + text.Text;
    			text.PartialTextChanged += (sender, args) => text.Text = "" + text.Text;
    			text.SelectedObjectChanged += (sender, args) => text.Text = "" + text.Text;
    		}
