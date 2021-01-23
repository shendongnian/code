    foreach (var control in this.Controls) // I guess this is your form
                {
                    if (control is CheckBox)
                    {
                        if (((CheckBox)control).Checked)
                        {
                            //update
                        }
                        else
                        {
                            //update another
                        }
                    }
                }
