    btn.Click += (senders, eventArgs) =>
                    {
                        foreach (ListViewItem lvis in lvSales.Items)
                        {
                            if (lvis.SubItems[0].Text == btn.Text)
                            {
                                //get current quantity of listitem, increment it,     
                                //add the new value to this listitem quantity value...
                                //keep track of current index, use that to set the new value...
                            }
                            else
                            {
                                //re instantiate listviewitem, set its values, and add it
                            }
                        }
                    };
