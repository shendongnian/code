    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    public class Formtest1
    {
	private void Button1_Click(object sender, EventArgs e)
	{
		if ((Formtest2 != null)) {
			Formtest2.TextBox1.Text = this.TextBox1.Text;
			if (Formtest2.Visible == false) {
				Formtest2.Show();
			} else {
				Formtest2.Focus();
			}
		}
	}
    }
