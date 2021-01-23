        /// <summary>
        /// Replace any of the contained controls with literals
        /// </summary>
        /// <param name="control"></param>
        private static void PrepareControlForExport(Control control)
            {
                for (int i = 0; i < control.Controls.Count; i++)
                {
                    Control current = control.Controls[i];
                    if (current is LinkButton)
                    {
                        control.Controls.Remove(current);
                        control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
                    }
                    else if (current is ImageButton)
                    {
                        control.Controls.Remove(current);
                        control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
                    }
                    else if (current is HyperLink)
                    {
                        control.Controls.Remove(current);
                        control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
                    }
                    else if (current is DropDownList)
                    {
                        control.Controls.Remove(current);
                        control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
                    }
                    else if (current is CheckBox)
                    {
                        control.Controls.Remove(current);
                        control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
                    }
                    else if (current is Label)
                    {
                        control.Controls.Remove(current);
                        control.Controls.AddAt(i, new LiteralControl((current as Label).Text));
                    }
            
                    if (current.HasControls())
                    {
                        GridViewExportUtil.PrepareControlForExport(current);
                    }
                }
            }
