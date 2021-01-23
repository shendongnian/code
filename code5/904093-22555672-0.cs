     foreach (GridDataItem item in radGridSahreaJob.MasterTableView.Items)
                {
                    CheckBox CheckBox1 = item.FindControl("chkIsCandidateSelected") as CheckBox;
                    TextBox TextBox1 = item.FindControl("txtMaxResumes") as TextBox;
                    string strTxtResumes = TextBox1.Text;
                    if (CheckBox1 != null && CheckBox1.Checked && string.IsNullOrEmpty(strTxtResumes))
                    {
                        hdnCheckBox.Value = "1"; 
                    }
                }
