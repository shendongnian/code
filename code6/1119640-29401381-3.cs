    string fetchContentString(object o)
            {
                if (o == null)
                {
                    return null;
                }
    
                if(o is string)
                {
                    return o.ToString();
                }
    
                if(o is ContentControl) //Button ButtonBase CheckBox ComboBoxItem ContentControl Frame GridViewColumnHeader GroupItem Label ListBoxItem ListViewItem NavigationWindow RadioButton RepeatButton ScrollViewer StatusBarItem ToggleButton ToolTip UserControl Window
                {
                    var cc = o as ContentControl;
    
                    if (cc.HasContent)
                    {
                        return fetchContentString(cc.Content);
                    }
                    else
                    {
                        return null;
                    }
    
                }
    
                if(o is Panel) //Canvas DockPanel Grid TabPanel ToolBarOverflowPanel ToolBarPanel UniformGrid StackPanel VirtualizingPanel VirtualizingPanel WrapPanel
                {
                    var p = o as Panel;
                    if (p.Children != null)
                    {
                        if (p.Children.Count > 0)
                        {
                            if(p.Children[0] is ContentControl)
                            {
                                return fetchContentString((p.Children[0] as ContentControl).Content);
                            }else
                            {
                                return fetchContentString(p.Children[0]);
                            }
                        }
                    }
                }
    
                //Those are special
                if(o is TextBoxBase) // TextBox RichTextBox PasswordBox
                {
                    if(o is TextBox)
                    {
                        return (o as TextBox).Text;
                    }
                    else if(o is RichTextBox)
                    {
                        var rt = o as RichTextBox;
                        if (rt.Document == null) return null;
                        return new TextRange(rt.Document.ContentStart, rt.Document.ContentEnd).Text;
                    }
                    else if(o is PasswordBox)
                    {
                        return (o as PasswordBox).Password;
                    }
                }
    
                return null;
            }
