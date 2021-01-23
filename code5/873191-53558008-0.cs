    public string GetSelectedRadioButtonText(RadioButton[] radioButtons)
    {
        // possible additional checks: check multiple selected, check if at least one is selected and generate more descriptive exception.
        // works for above cases, but throws a generic InvalidOperationException if it fails
        return radioButtons.Single(r => r.Checked).Text;
    }
    public void YourMethod()
    {
        Class1.ABC("insert into emp(code,names,m_name,desgnation,gender) 
                    values('" + textBox1.Text + "', '" + 
                                 textBox2.Text + "','" +
                                 textBox3.Text + "','" +
                                 textBox4.Text + "','" +
                                 textBox5.Text + "','" +
                                 this.GetSelectedRadioButtonText(new[] { rb1, rb2 }) + "' )");
    }
