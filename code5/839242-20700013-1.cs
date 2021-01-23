        Hope this will help you like this you can get the value of label too.
        
    public void GetControlsValuePopulated(Control control, Type controlType, Dictionary<string, string> dictControlPageValParam)
                        {
                            try
                            {
                
                                if (control.HasControls())
                                {
                                    GetControlsValuePopulated(control, controlType, dictControlPageValParam);
                                }
                                else
                                {
                                    if (controlType == null || controlType.IsAssignableFrom(control.GetType()))
                                    {
                                        if (control.ID != null)
                                        {
                                            bool FoundControl = dictControlPageValParam.ContainsKey(control.ID.Substring(3));
                                            if (FoundControl)
                                            {
                                                switch (control.GetType().ToString())
                                                {
                                                    case "System.Web.UI.WebControls.TextBox":
                                                        TextBox txt = (TextBox)control;
                                                        txt.Text = dictControlPageValParam[txt.ID.Substring(3)];
                                                        break;
                
                                                    case "System.Web.UI.WebControls.CheckBox":
                                                        CheckBox chk = (CheckBox)control;
                                                        if (dictControlPageValParam[chk.ID.Substring(3)].ToUpper() == "TRUE" || dictControlPageValParam[chk.ID.Substring(3)].ToUpper() == "T")
                                                        {
                                                            chk.Checked = true;
                                                        }
                                                        else
                                                        {
                                                            chk.Checked = false;
                                                        }
                                                        break;
                
                                                    case "System.Web.UI.WebControls.DropDownList":
                                                        DropDownList ddl = (DropDownList)control;
                                                        //ddl.SelectedValue = dictControlPageValParam[ddl.ID.Substring(3)];
                                                        break;
                
                                                    case "System.Web.UI.WebControls.RadioButtonList":
                                                        RadioButtonList rbl = (RadioButtonList)control;
                                                        rbl.SelectedValue = dictControlPageValParam[rbl.ID.Substring(3)];
                                                        break;
                
                                                    case "System.Web.UI.WebControls.HiddenField":
                                                        HiddenField hdn = (HiddenField)control;
                                                        hdn.Value = dictControlPageValParam[hdn.ID.Substring(3)];
                                                        break;
                                                }
                                            }
                                        }
                
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                        }
                
                        public void GetChildControlsId(Control control, Type controlType)
                        {
                            try
                            {
                
                                if (control.HasControls())
                                {
                                    GetChildControlsId(control, controlType);
                                }
                                else
                                {
                                    if (controlType == null || controlType.IsAssignableFrom(control.GetType()))
                                    {
                                        ///checking if control already existing in the collection
                                        if (control.ID != null)
                                        {
                                            bool FoundControl = controlHt.ContainsKey(control.ID);
                
                                            if (!FoundControl)
                                            {
                                                switch (control.GetType().ToString())
                                                {
                                                    case "System.Web.UI.WebControls.TextBox":
                                                        TextBox txt = (TextBox)control;
                                                        controlTypeName = txt.ID;
                                                        controlTypeName = controlTypeName.Substring(3);
                                                        controlTypeValue = txt.Text;
                                                        if (dictControlValParam.ContainsKey(controlTypeName) == false)
                                                        {
                                                            dictControlValParam.Add(controlTypeName, controlTypeValue);
                                                        }
                                                        else
                                                        {
                                                            dictControlValParam.Remove(controlTypeName);
                                                            dictControlValParam.Add(controlTypeName, controlTypeValue);
                                                        }
                                                        break;
                
                
                                                    case "System.Web.UI.WebControls.CheckBox":
                                                        CheckBox chk = (CheckBox)control;
                                                        controlTypeName = chk.ID;
                                                        controlTypeName = controlTypeName.Substring(3);
                                                        controlTypeValue = chk.Checked.ToString();
                                                        if (dictControlValParam.ContainsKey(controlTypeName) == false)
                                                        {
                                                            dictControlValParam.Add(controlTypeName, controlTypeValue);
                                                        }
                                                        else
                                                        {
                                                            dictControlValParam.Remove(controlTypeName);
                                                            dictControlValParam.Add(controlTypeName, controlTypeValue);
                                                        }
                                                        break;
                                                    case "System.Web.UI.WebControls.DropDownList":
                                                        DropDownList ddl = (DropDownList)control;
                                                        controlTypeName = ddl.ID;
                                                        controlTypeName = controlTypeName.Substring(3);
                                                        controlTypeValue = ddl.SelectedValue.ToString();
                                                        if (dictControlValParam.ContainsKey(controlTypeName) == false)
                                                        {
                                                            dictControlValParam.Add(controlTypeName, controlTypeValue);
                                                        }
                                                        else
                                                        {
                                                            dictControlValParam.Remove(controlTypeName);
                                                            dictControlValParam.Add(controlTypeName, controlTypeValue);
                                                        }
                                                        break;
                                                    case "System.Web.UI.WebControls.RadioButtonList":
                                                        RadioButtonList rbl = (RadioButtonList)control;
                                                        controlTypeName = rbl.ID;
                                                        controlTypeName = controlTypeName.Substring(3);
                                                        controlTypeValue = rbl.SelectedValue.ToString();
                                                        if (dictControlValParam.ContainsKey(controlTypeName) == false)
                                                        {
                                                            dictControlValParam.Add(controlTypeName, controlTypeValue);
                                                        }
                                                        else
                                                        {
                                                            dictControlValParam.Remove(controlTypeName);
                                                            dictControlValParam.Add(controlTypeName, controlTypeValue);
                                                        }
                                                        break;
                
                                                    case "System.Web.UI.WebControls.HiddenField":
                                                        HiddenField hdn = (HiddenField)control;
                                                        controlTypeName = hdn.ID;
                                                        controlTypeName = controlTypeName.Substring(3);
                                                        controlTypeValue = hdn.Value;
                                                        if (dictControlValParam.ContainsKey(controlTypeName) == false)
                                                        {
                                                            dictControlValParam.Add(controlTypeName, controlTypeValue);
                                                        }
                                                        else
                                                        {
                                                            dictControlValParam.Remove(controlTypeName);
                                                            dictControlValParam.Add(controlTypeName, controlTypeValue);
                                                        }
                                                        break;
                                                }
                
                                            }
                
                                        }
                
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                        }
