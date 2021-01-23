	void SetTextBoxReadOnly(bool val, param TextBox[] textBoxes)
	{
		if(textBoxes != null && textBoxes.Length > 0)
		{
			foreach(TextBox textBox in textBoxes)
			{
				if(textBox != null)
				{
					textBox.ReadOnly = val;
				}
			}
		}
	}
	void SetControlEnabled(bool val, param Control[] ctrls)
	{
		if(ctrls != null && ctrls.Length > 0)
		{
			foreach(Control ctrl in ctrls)
			{
				if(ctrl != null)
				{
					ctrl.Enabled = val;
				}
			}
		}
	}
	// etc set of methods for similar situations.
	// there methods can be invoked as
	...
	...
	...
	SetTextBoxReadOnly(true, txtProductCode1,
							 txtInvoiceNo,
							 txtQty,
							 txtPercant,
							 txtDiscount);
