        #region CreateControl() Overloads
                /// <summary>
                /// Creates a LinkButton control.
                /// </summary>
                /// <param name="objText">.Text property of this LinkButton control.</param>
                /// <param name="pnl">Panel this control will be attached to.</param>
                /// <param name="hndl">Event handler attached to this LinkButton control.</param>
                /// <param name="HTMLTag">Opening tag used to contain this control.</param>
                private void CreateControl(string objText,
                                           Panel pnl,
                                           EventHandler hndl,
                                           string HTMLTag)
                {
                    pnl.Controls.Add(new LiteralControl(HTMLTag));
                    LinkButton obj = new LinkButton();
                    obj.Text = objText;
                    obj.Click += new EventHandler(hndl);
    
                    pnl.Controls.Add(obj);
                    pnl.Controls.Add(new LiteralControl(HTMLTag.Insert(1, "/")));
                }
                /// <summary>
                /// Creates a Label control.
                /// </summary>
                /// <param name="objText">.Text property of this Label control.</param>
                /// <param name="pnl">Panel this control will be attached to.</param>
                /// <param name="HTMLTag">Opening tag used to contain this control.</param>
                private void CreateControl(string objText,
                                           Panel pnl,
                                           string HTMLTag)
                {
                    pnl.Controls.Add(new LiteralControl(HTMLTag));
                    Label obj = new Label();
                    obj.Text = objText;
    
                    pnl.Controls.Add(obj);
                    pnl.Controls.Add(new LiteralControl(HTMLTag.Insert(1, "/")));
                }
                /// <summary>
                /// Creates the specified literal control.
                /// </summary>
                /// <param name="ControlText">HTML text containing instructions for creating the desired literal control.</param>
                /// <param name="pnl">Panel this literal control will be attached to.</param>
                private void CreateControl(string ControlText, 
                                           Panel pnl)
                {
                    pnl.Controls.Add(new LiteralControl(ControlText));
                }
            #endregion
