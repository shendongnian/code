                                if (_ActiveControl is Form)
                                {
                                    if ((_ActiveControl is {form name for public chat window}) || (_ActiveControl is {form name for private chat window}) || (_ActiveControl is {form name for Group chat window}))
                                    {
                                        _ActiveForm = (Form)_ActiveControl;
                                        _ActiveForm.Activate();
                                        _ActiveForm.Focus();
                                        TextBox _tb = (TextBox)_ActiveForm.Controls.Find("txtMessage", true).FirstOrDefault();
                                        _tb.Select(_tb.Text.Length, 0);
                                    }
                                }
                            }
