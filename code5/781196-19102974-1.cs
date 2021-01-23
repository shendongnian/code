    public bool Check_CheckBox
            {
                set
                {
                    checkbox1.Checked = value;
                    if (value)
                    {
                        checkbox1.CheckedChanged -= new EventHandler(this.Check_Clicked);
                    }
                }
                get
                {
                    return checkbox1.Checked;
                }
            }
