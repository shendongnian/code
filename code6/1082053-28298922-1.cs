    private void myDataGridMain_KeyDown(object sender, KeyEventArgs e)
            {
                DataGridCell cell = sender as DataGridCell;
    
                if (e.Key == Key.Enter)
                {   //give cell the focus
                    cell.Focus();
                }
                else
                {
                    if ((cell != null))
                    {
                        TextBox textbox = FindVisualChild<TextBox>(cell);
                        if (textbox != null)
                        {   //TextBox has benn found
                            if ((textbox as TextBox).IsFocused == false)
                            {
                                (textbox as TextBox).SelectAll();
                            }
                            (textbox as TextBox).Focus();
                        }
    
                        CheckBox chkbox = FindVisualChild<CheckBox>(cell);
                        if (chkbox != null)
                        {   //Checkbox has been found
                            (chkbox as CheckBox).Focus();
                        }
    
                        ComboBox combbox = FindVisualChild<ComboBox>(cell);
                        if (combbox != null)
                        {   //ComboBox has been found
                            (combbox as ComboBox).Focus();
                        }
                    }
                }
            }
